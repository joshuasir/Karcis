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
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            if (HttpContext.Session.GetString("Token") == null)
            {
                return RedirectToAction("Login", "Registry");
            }
            if (HttpContext.Session.GetString("UserRole") != "True")
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public async Task<IActionResult> GetAllPayments()
        {
            if (HttpContext.Session.GetString("Token") == null)
            {
                return RedirectToAction("Login", "Registry");
            }
            if (HttpContext.Session.GetString("UserRole") != "True")
            {
                return RedirectToAction("Index", "Home");
            }
            var client = new HttpClient();
            
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost:42069/booking"),
                Content = new StringContent("", Encoding.UTF8, MediaTypeNames.Application.Json /* or "application/json" in older versions */),
            };

            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var bookings = JsonConvert.DeserializeObject<List<BookingViewModel>>(responseBody);

            return View("Payments", bookings);
        }

        public async Task<BookingViewModel> GetBookingByID(int id)
        {
            if (HttpContext.Session.GetString("UserRole") != "True" || HttpContext.Session.GetString("Token") == null)
            {
                return null;
            }

            var client = new HttpClient();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost:42069/booking/specific?BookNumber="+id),
                Content = new StringContent("", Encoding.UTF8, MediaTypeNames.Application.Json /* or "application/json" in older versions */),
            };

            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var booking = JsonConvert.DeserializeObject<BookingViewModel>(responseBody);

            return booking;
        }

        public async Task<IActionResult> ChangeBookingStatus(int id, string status)
        {
            if (HttpContext.Session.GetString("Token") == null)
            {
                return RedirectToAction("Login", "Registry");
            }
            if (HttpContext.Session.GetString("UserRole") != "True")
            {
                return RedirectToAction("Index", "Home");
            }
            var client = new HttpClient();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Patch,
                RequestUri = new Uri("http://localhost:42069/booking"),
                Content = new StringContent(
                "{\"BookingNumber\":" + id + "," +
                " \"Status\":\"" + status + "\"," +
                "\"UserToken\":\"" + HttpContext.Session.GetString("Token") + "\"}", Encoding.UTF8, MediaTypeNames.Application.Json /* or "application/json" in older versions */),
            };

            request.Headers.Add("Authorization", "Admin");

            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            JsonResult Ret = Json(new
            {
                Status = true,
                Message = "Berhasil Update Status"
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
