using Binus.WS.Pattern.Entities;
using karcis_API.Model;
using karcis_API.Model.DTO;
using karcis_API.Output;
using System;
using System.Collections.Generic;
using System.Linq;

namespace karcis_API.Helper
{
    public class EventHelper
    {
        public static List<Event> GetAll(string keyword, bool current) // get all currently available event
        {
            var events = new List<Event>();
            try
            {
                // get event
                events = EntityHelper.Get<Event>().
                    Where(e => (current == false || DateTime.Compare((DateTime)e.EventStart, DateTime.Now) <= 0 && DateTime.Compare((DateTime)e.EventEnd, DateTime.Now) >= 0) && (keyword ==null||e.EventName.Contains(keyword))).
                    ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
            return events;
        }
        /* Commented By Joshua
         * Date : 13/02/2022
         * For CRUD Event not needed for App
         * 
        public static string Create(CreateEventDTO EventInfo) // create new event
        {

            try
            {              
                var Admin = EntityHelper.Get<User>().Where(e => e.UserID == EventInfo.EventData.CreatedBy && e.UserRole).FirstOrDefault();

                if (Admin==null)
                {
                    throw new Exception("Invalid Credentials");
                }

                var EventData = EventInfo.EventData;

                EntityHelper.Add(new Event()
                {
                    EventName = EventData.EventName,
                    EventLocation = EventData.EventLocation,
                    CreatedAt = DateTime.Now,
                    CreatedBy = EventData.CreatedBy,
                    EventStart = Convert.ToDateTime(EventInfo.StartDate),
                    EventEnd = Convert.ToDateTime(EventInfo.EndDate),
                    EventDescription = EventData.EventDescription
                });
                var EventFromDB = EntityHelper.Get<Event>().OrderBy(e=>e.CreatedAt).ToList().Last();


                EventInfo.Tickets.ForEach(e =>
                {
                    int qty = e.Qty;
                    if (qty >= 1e7 || qty < 0)
                    {
                        throw new Exception("Invalid Amount");
                    }
                    var TicketData = e.TicketData;
                    while (qty-- > 0)
                    {
                        EntityHelper.Add(new Ticket()
                        {
                            EventID = EventFromDB.EventID,
                            TicketPrice = TicketData.TicketPrice,
                            TicketType = TicketData.TicketType
                        });
                    }
                });
                return "Successful";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }

        }

        public static string Update(CreateEventDTO EventInfo) 
        {

            try
            {
                var Admin = EntityHelper.Get<User>().Where(e => e.UserID == EventInfo.EventData.UpdatedBy && e.UserRole).FirstOrDefault();

                if (Admin == null)
                {
                    throw new Exception("Invalid Credentials");
                }

                var EventToUpdt = EntityHelper.Get<Event>().Where(e => e.EventID == EventInfo.EventData.EventID).FirstOrDefault();
                
                if (EventToUpdt == null)
                {
                    throw new Exception("Not Found");
                }
                var EventID = EventToUpdt.EventID;
                EventToUpdt.EventDescription = EventInfo.EventData.EventDescription ?? EventToUpdt.EventDescription;
                EventToUpdt.EventName = EventInfo.EventData.EventName ?? EventToUpdt.EventName;
                EventToUpdt.EventLocation = EventInfo.EventData.EventLocation ?? EventToUpdt.EventLocation;
                EventToUpdt.EventEnd = EventInfo.EventData.EventEnd ?? EventToUpdt.EventEnd;
                EventToUpdt.EventStart = EventInfo.EventData.EventStart ?? EventToUpdt.EventStart;
                EventToUpdt.UpdateAt = DateTime.Now;
                EventToUpdt.UpdatedBy = EventInfo.EventData.UpdatedBy;

                EntityHelper.Update(EventToUpdt);

                var Tickets = EntityHelper.Get<Ticket>().Where(e => e.EventID == EventInfo.EventData.EventID).ToList().
                    GroupBy(e => e.TicketType).
                    Select(e=> new { 
                        TicketType = e.Key,
                        CurrentAvl = e.Count(ee=>ee.TicketStatus),
                        TypeQty = e.Count()
                    }).ToList();

                EventInfo.Tickets.ForEach(e =>
                {
                    var CurrQty = Tickets.Where(f => f.TicketType == e.TicketData.TicketType).FirstOrDefault();
                    var diff = e.Qty-(CurrQty==null ? 0 : CurrQty.TypeQty);
                    var TicketData = e.TicketData;
                    var amount = Math.Abs(diff);

                    if (e.Qty >= 1e7 || e.Qty<0 || (diff < 0 && CurrQty!=null && CurrQty.CurrentAvl < Math.Abs(diff)))
                    {
                        throw new Exception("Invalid Amount");
                    }

                    if (diff < 0)
                    {
                        EntityHelper.Get<Ticket>().
                            Where(f => f.TicketStatus && f.TicketType == TicketData.TicketType && f.EventID == EventID).
                            Take(amount).ToList().ForEach(g =>
                            {
                                EntityHelper.Delete(g);
                            });
                    }
                    else if (diff > 0)
                    {
                        while (diff-- > 0)
                        {
                            EntityHelper.Add(new Ticket()
                            {
                                EventID = EventID,
                                TicketPrice = TicketData.TicketPrice,
                                TicketType = TicketData.TicketType
                            });
                        }
                    }
                });

                return "Successful";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }

        }


        public static string Delete(int EventID) 
        {

            try
            {

                var Tickets = EntityHelper.Get<Ticket>().Where(e => e.EventID == EventID).ToList();
                Tickets.ForEach(e =>
                {
                    EntityHelper.Delete(e);
                });
                var EventToDelete = EntityHelper.Get<Event>().Where(e => e.EventID == EventID).FirstOrDefault();
                if (EventToDelete == null)
                {
                    return "Not Found";
                }

                EntityHelper.Delete(EventToDelete);

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
