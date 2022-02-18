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
    public class HistoryController : Controller
    {
        private readonly ILogger<HistoryController> _logger;

        public HistoryController(ILogger<HistoryController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            if (HttpContext.Session.GetString("Token") == null)
            {
                return RedirectToAction("Login", "Registry");
            }
            var HomeView = new HomeViewModel()
            {
                User = new UserModel()
                {
                    UserName = HttpContext.Session.GetString("UserName")
                }

            };
            Console.WriteLine(HomeView.User.UserName);
            return View(HomeView);
        }

        public async Task<IActionResult> GetAllBookingHistory()
        {
            if (HttpContext.Session.GetString("Token") == null)
            {
                return RedirectToAction("Login", "Registry");
            }

            var HistoryView = new UserModel()
            {
                UserID = (int)HttpContext.Session.GetInt32("UserID")
            };

            var client = new HttpClient();
            // request booking history
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost:42069/booking?UserID=" + HistoryView.UserID),
                Content = new StringContent("", Encoding.UTF8, MediaTypeNames.Application.Json /* or "application/json" in older versions */),
            };

            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            
            // list of user history
            var bookings = JsonConvert.DeserializeObject<List<BookingViewModel>>(responseBody);

            return View("BookingHistory", bookings);
        }

        public async Task<IActionResult> GetBookingByID(int id)
        {
            if (HttpContext.Session.GetString("Token") == null)
            {
                return RedirectToAction("Login", "Registry");
            }

            var client = new HttpClient();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost:42069/ticket/specific?BookingID=" + id),
                Content = new StringContent("", Encoding.UTF8, MediaTypeNames.Application.Json /* or "application/json" in older versions */),
            };

            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var tickets = JsonConvert.DeserializeObject<List<TicketViewModel>>(responseBody);

            return View("BookingDetail",tickets);
        }
        /*
         Modified by Joshua
         Date : 10/02/2022
         Purpose : added string content
         */
        public async Task<IActionResult> CancelBooking(int id)
        {
            // validate logged in user
            if (HttpContext.Session.GetString("Token") == null)
            {
                return RedirectToAction("Login", "Registry");
            }
            var client = new HttpClient();

            // delete request
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri("http://localhost:42069/booking"),
                Content = new StringContent("" +
                "{\"BookingID\":" + id + "," +
                " \"UserID\":" + HttpContext.Session.GetInt32("UserID") + "," +
                "\"UserToken\":\"" + HttpContext.Session.GetString("Token") + "\"}" +
                "", Encoding.UTF8, MediaTypeNames.Application.Json)
            };

            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            JsonResult Ret = Json(new
            {
                Status = true,
                Message = "Berhasil delete"
            });

            return Ret;
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
