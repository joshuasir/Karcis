using Binus.WS.Pattern.Entities;
using karcis_API.Model;
using karcis_API.Model.DTO;
using karcis_API.Output;
using System;
using System.Collections.Generic;
using System.Linq;

namespace karcis_API.Helper
{
    public class TicketHelper
    {
        public static List<TicketOutput> GetAvailable(string EventName) 
        {
            
            try
            {
                // get available ticket based on event groupby type
                var Events = EntityHelper.Get<Event>().ToList();
                var Tickets = EntityHelper.Get<Ticket>().ToList().
                    Join(Events,
                    tickets=> tickets.EventID,
                     events => events.EventID,
                    (tickets, events) => new { tickets, events })
                   .Where(e => e.tickets.TicketStatus && e.events.EventName.Contains(EventName)).
                    GroupBy(e=> new { e.tickets.TicketType,e.tickets.TicketPrice}).
                    Select(e=>new TicketOutput() { 
                        TicketType = e.Key.TicketType,
                        TicketPrice = e.Key.TicketPrice,
                        Qty = e.Count(),

                    }).
                    ToList(); // ambil semua available ticket berdasarkan event and type
                return Tickets;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }

        }

        public static Ticket GetSpecific(int TicketID) 
        {
            var Ticket = new Ticket();
            try
            {
                Ticket = EntityHelper.Get<Ticket>()
                    .Where(e => e.TicketID == TicketID).
                    FirstOrDefault();
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
            return Ticket;
        }

        public static List<TicketOutput> GetSpecificByBooking(int BookingNumber) 
        {
            var Tickets = new List<TicketOutput>();
            try
            {
                // get booking ticket by booking number group by type
                Tickets = CompositeEntityHelper.Get<Booking>(e=>new { e.BookingNumber,e.TicketID})
                    .Where(e => e.BookingNumber == BookingNumber).ToList().
                    Join(
                    EntityHelper.Get<Ticket>().ToList(),
                    booking=>booking.TicketID,
                    ticket=>ticket.TicketID,
                    (booking, ticket) => new { 
                        ticket.TicketID,
                        ticket.TicketType,
                        ticket.TicketPrice,
                        ticket.EventID
                    }).GroupBy(e=>new { e.TicketType,e.TicketPrice})
                    .Select(e=> new TicketOutput(){ 
                       TicketType = e.Key.TicketType,
                       TicketPrice = e.Key.TicketPrice,
                       Qty = e.Count()
                    }).ToList();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
            return Tickets;
        }
/*
 * Commented By Joshua
 * Date : -
 * Moved to create Event
 * 
        public static string Create(CreateTicketDTO TicketAdd) 
        {
            var TicketData = TicketAdd.TicketData;
            try
            {
                while (TicketAdd.Qty-- > 0)
                {
                    EntityHelper.Add(new Ticket()
                    {
                        TicketPrice = TicketData.TicketPrice,
                        TicketType = TicketData.TicketType,
                        EventID = TicketData.EventID
                    });
                }

                return "Successful";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }

        }
*/

    }
}
