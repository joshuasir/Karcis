using Karcis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Net.Mime;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Karcis.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        public async Task<IActionResult> IndexAsync()
        {
            
            var client = new HttpClient();

            // get event data
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost:42069/event?keyword=FEST"),
                Content = new StringContent("", Encoding.UTF8, MediaTypeNames.Application.Json /* or "application/json" in older versions */),
            };

            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var events = JsonConvert.DeserializeObject<Events>(responseBody);
            var HomeView = new HomeViewModel()
            {
                Event = events.events[0],
                User = new UserModel()
                {
                    UserName = HttpContext.Session.GetString("UserName")
                }

            };
            return View(HomeView);
        }

        public async Task<IActionResult> Ticket()
        {
            var client = new HttpClient();
            // request available ticket quantity
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost:42069/ticket?EventName=FEST"),
                Content = new StringContent("", Encoding.UTF8, MediaTypeNames.Application.Json /* or "application/json" in older versions */),
            };
            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            
            // map to dictionary for static calling
            var tickets = JsonConvert.DeserializeObject<List<TicketViewModel>>(responseBody);
            var TicketsDict = new Dictionary<string, TicketViewModel>();
            
            tickets.ForEach(e =>
            {
                if (!TicketsDict.ContainsKey(e.TicketType))
                {
                    TicketsDict.Add(e.TicketType, e);
                }
                
            });
            return View("MainTicket", TicketsDict);
        }
        
        [HttpPost]
        public async Task<IActionResult> Summary([FromBody] OrderDTO Booking)
            
        {
            // check if user is logged in
            if (HttpContext.Session.GetString("Token") == null)
            {
                return RedirectToAction("Login", "Registry");
            }
            // post order
            var client = new HttpClient();
            var body = "{\"EventName\":\"" + Booking.EventName + "\",\"Tickets\":[";
            int len = Booking.Tickets.Count();
            for (int i=0;i<len;i++)
            {
                body += "{\"TicketType\":\"" + Booking.Tickets[i].TicketType + "\", \"Qty\":" + Booking.Tickets[i].Qty + "}" + ((i + 1 >= len) ? "]" : ",");
            }
            body += ",\"UserID\":"+HttpContext.Session.GetInt32("UserID")+"," +
                "\"UserToken\":\"" + HttpContext.Session.GetString("Token") +
                "\"}";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost:42069/booking"),
                Content = new StringContent( body, Encoding.UTF8, MediaTypeNames.Application.Json /* or "application/json" in older versions */),
            };

            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            // var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            // return summary of order
            var BookingSummary = Booking.Tickets;

            
            return View("BookingSummary", BookingSummary);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
