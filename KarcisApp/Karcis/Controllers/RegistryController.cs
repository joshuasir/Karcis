using Karcis.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Karcis.Controllers
{
    public class RegistryController : Controller
    {
        private static readonly string salt = BCrypt.Net.BCrypt.GenerateSalt();
        public async Task<IActionResult> Login()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
        /*
         Modified by Joshua
         Date : 09/02/2022
         Purpose : added session
         */
        [HttpPost]
        public async Task<IActionResult> LoginRequest([FromBody] UserModel User)
        {
            try
            {
                var client = new HttpClient();
                // request data from API
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("http://localhost:42069/user/login"),
                    Content = new StringContent("{\"UserEmail\":\"" + User.UserEmail + "\", \"UserPassword\":\"" + User.UserPassword + "\"}", Encoding.UTF8, MediaTypeNames.Application.Json /* or "application/json" in older versions */),
                };

                var response = await client.SendAsync(request).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                // get user data
                var user = JsonConvert.DeserializeObject<UserModel>(responseBody);

                if (!BCrypt.Net.BCrypt.Verify(User.UserPassword, user.UserPassword)) throw new Exception("Invalid Password");

                // set session
                HttpContext.Session.SetInt32("UserID", user.UserID);
                HttpContext.Session.SetString("UserName", user.UserName);
                HttpContext.Session.SetString("Token", user.Token);
                HttpContext.Session.SetString("UserRole", user.UserRole.ToString());
                ViewBag.UserName = user.UserName;
                ViewData["UserName"] = user.UserName;
                return Json(new
                {
                    Status = true,
                    Message = "Logged in!"
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    Status = false,
                    Message = e.Message
                });
            }
        }
        // send email after registration
        [HttpPost] 
        public async Task<IActionResult> SendEmail([FromBody] UserModel User)
        {
            try {
                var client = new HttpClient();
                // post user data to API
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("http://localhost:42069/user/register"),
                    Content = new StringContent(
                    "{\"UserEmail\":\"" + User.UserEmail + "\"," +
                    " \"UserPassword\":\"" + BCrypt.Net.BCrypt.HashPassword(User.UserPassword,salt) + "\"," +
                    "\"UserName\":\"" + User.UserName + "\"," +
                    "\"UserDOB\":\"" + User.UserDOB + "\"," +
                    "\"UserPhone\":\"" + User.UserPhone + "\"}"
                    , Encoding.UTF8, MediaTypeNames.Application.Json /* or "application/json" in older versions */),
                };

                var response = await client.SendAsync(request).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                return Json(new
                {
                    Status = true,
                    Message = "Registered!"
                }); 
            }
            catch (Exception e)
            {
                return Json(new
                {
                    Status = false,
                    Message = e.Message
                });
            }
        }
        // validate user email
        public async Task<IActionResult> Verify(string Token)
        {
            try
            {
                var client = new HttpClient();

                // request to API
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("http://localhost:42069/user/verify?Token=" + Token),
                    Content = new StringContent("", Encoding.UTF8, MediaTypeNames.Application.Json /* or "application/json" in older versions */),
                };

                var response = await client.SendAsync(request).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
            //redirect to login
            return View("Login");
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
