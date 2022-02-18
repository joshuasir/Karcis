using Binus.WS.Pattern.Entities;
using karcis_API.Model;
using karcis_API.Model.DTO;
using karcis_API.Output;
using System;
using System.Collections.Generic;
using System.Linq;

namespace karcis_API.Helper
{
    public class BookingHelper
    {
        public static List<BookingOutput> GetByID(int? UserID)
        {

            var Bookings = new List<BookingOutput>();
            try
            {
                // get user data
                var UserData = EntityHelper.Get<User>().Where(e => UserID == null || e.UserID == UserID ).ToList();
                
                // get ticket data
                var TicketData = EntityHelper.Get<Ticket>().ToList();
                
                // return not found
                if(UserData == null)
                {
                    return null;
                }

                // get booking data, total price, group by user
                Bookings = CompositeEntityHelper.Get<Booking>(e => new { e.TicketID,e.BookingNumber}).
                    OrderByDescending(e=>e.CreatedAt).ToList().
                Join(TicketData,
                booking => booking.TicketID,
                ticket => ticket.TicketID,
                (booking, ticket) => new {
                    booking.BookingNumber,
                    booking.UserID,
                    ticket.TicketID,
                    booking.Status,
                    booking.Qty,
                    ticket.TicketPrice 
                }).
                Join(UserData,
                booking2 => booking2.UserID,
                user => user.UserID,
                (booking2, user) => new {
                    booking2.BookingNumber,
                    booking2.UserID,
                    booking2.TicketID,
                    booking2.Status,
                    booking2.Qty,
                    booking2.TicketPrice,
                    user.UserName
                }).
                GroupBy(e=> new {
                    e.UserID,
                    e.BookingNumber,
                    e.Status, 
                    e.Qty ,
                    e.UserName
                }).
                Select(e=> new BookingOutput() { 
                    BookingNumber = e.Key.BookingNumber,
                    Status = e.Key.Status,
                    Qty = e.Sum(ee=>ee.Qty),
                    UserID = e.Key.UserID,
                    UserName = e.Key.UserName,
                    TotalPrice = e.Sum(ee=>ee.Qty * ee.TicketPrice)

                })
                .ToList();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
            return Bookings;
        }
        public static BookingOutput GetByBookingID(int BookingID)
        {

            var Bookings = new BookingOutput();
            try
            {
                // get ticket
                var TicketData = EntityHelper.Get<Ticket>().ToList();

                // get booking data, total price, group by user by booking number
                Bookings = CompositeEntityHelper.Get<Booking>(e => new { e.TicketID, e.BookingNumber }).
                Where(e => e.BookingNumber == BookingID).ToList().
                Join(TicketData,
                booking => booking.TicketID,
                ticket => ticket.TicketID,
                (booking, ticket) => new {
                    booking.BookingNumber,
                    booking.UserID,
                    ticket.TicketID,
                    booking.Status,
                    booking.Qty,
                    ticket.TicketPrice
                }).
                GroupBy(e => new {
                    e.UserID,
                    e.BookingNumber,
                    e.Status,
                    e.Qty
                }).
                Select(e => new BookingOutput()
                {
                    BookingNumber = e.Key.BookingNumber,
                    Status = e.Key.Status,
                    Qty = e.Sum(ee => ee.Qty),
                    UserID = e.Key.UserID,
                    TotalPrice = e.Sum(ee => ee.Qty * ee.TicketPrice)

                })
                .FirstOrDefault();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
            return Bookings;
        }
        public static string Create(CreateBookingDTO Bookings)
        {
            
        try
        {
                var validToken = UserHelper.validateToken(Bookings.UserToken);
                if (validToken.Claims.Count()==0)
                {
                    throw new Exception("Invalid Token");
                }
                // order booking tickets
                int BookingNumber = CompositeEntityHelper.Get<Booking>(e => new { e.BookingNumber, e.TicketID }).Select(e => e.BookingNumber).Max() + 1;
                var TicketEvent = EntityHelper.Get<Ticket>().Where(e => e.TicketStatus).ToList().
                    Join(EntityHelper.Get<Event>().Where(e => e.EventName.Contains(Bookings.EventName)).ToList(),
                    ticket => ticket.EventID,
                    events => events.EventID,
                    (ticket, events) => ticket
                    ).ToList();

                Bookings.Tickets.ForEach(f =>
                {
                    var Tickets = TicketEvent.Where(e => e.TicketType == f.TicketType).Take(f.Qty).ToList();
                        if (Tickets.Count() == f.Qty) {
                            Tickets.ForEach((e) => // update ticket status
                            {
                                e.TicketStatus = false;
                                EntityHelper.Update(e);
                            }
                            );
                            Tickets.ForEach(e =>
                            CompositeEntityHelper.Add(e => new { e.TicketID, e.BookingNumber },
                            new Booking() // add booking per ticket
                            {
                                BookingNumber = BookingNumber,
                                TicketID = e.TicketID,
                                UserID = Bookings.UserID,
                                CreatedAt = DateTime.Now
                            })

                            ); 
                        }
                });

            return "Successful";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public static string UpdateStatus(UpdateBookingDTO BookingData)
        {
            try
            {
                // validate user
                var validToken = UserHelper.validateToken(BookingData.UserToken);
                if (validToken.Claims.Count() == 0)
                {
                    throw new Exception("Invalid Token");
                }
                // update status oleh admin
                var toUpdt = CompositeEntityHelper.Get<Booking>(e => new { e.TicketID, e.BookingNumber }).
                    Where(e => e.BookingNumber == BookingData.BookingNumber).ToList().
                    Join(EntityHelper.Get<Ticket>().ToList(),
                    booking => booking.TicketID,
                    ticket => ticket.TicketID,
                    (booking,ticket) => new { booking,ticket}
                    ).ToList();
                if (toUpdt == null)
                {
                    throw new Exception("Not Found");
                }
                // update status sesuai input admin
                toUpdt.ForEach(e =>
                {
                    e.booking.Status = BookingData.Status;
                    CompositeEntityHelper.Update(
                        i=>new {i.TicketID,i.BookingNumber}, e.booking);
                    
                });
                // jika status declined per ticket update status available
                if (BookingData.Status == "Declined")
                {
                    toUpdt.ForEach(e =>
                    {
                        e.ticket.TicketStatus = true;
                        EntityHelper.Update(e.ticket);
                    });
                }
                return "Successful";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public static string Cancel(CancelBookingDTO BookingData)
        {
            try
            {
                // validate user
                var validToken = UserHelper.validateToken(BookingData.UserToken);
                if (validToken.Claims.Count() == 0)
                {
                    throw new Exception("Invalid Token");
                }
                // cancel booking
                var toDel = CompositeEntityHelper.Get<Booking>(e => new { e.TicketID, e.BookingNumber }).
                    Where(
                    e=> (BookingData.TicketID == null || e.TicketID == BookingData.TicketID) &&
                    (e.UserID == BookingData.UserID) &&
                    ( BookingData.BookingID == null || e.BookingNumber == BookingData.BookingID)
                    ).ToList();

                if (toDel == null)
                {
                    throw new Exception("Invalid Token"); ;
                }
                // set ticket status available
                toDel.ForEach(f =>
                {

                    var unordered_ticket = EntityHelper.Get<Ticket>().Where(e => e.TicketID == f.TicketID).FirstOrDefault();
                    unordered_ticket.TicketStatus = true;
                    EntityHelper.Update(unordered_ticket);

                    CompositeEntityHelper.Delete(e => new { e.TicketID, e.BookingNumber }, f);

                });

                return "Successful";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }
    }
}

