using Binus.WS.Pattern.Entities;
using Binus.WS.Pattern.Service;
using karcis_API.Helper;
using karcis_API.Model.DTO;
using karcis_API.Output;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace karcis_API.Service
{
    [ApiController]
    [Route("booking")]
    public class BookingService : BaseService
    {
        public BookingService(ILogger<BaseService> logger) : base(logger)
        {
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(BookingOutput), StatusCodes.Status200OK)]
        public IActionResult GetAllBookingByID([FromQuery] int? UserID)
        {
            try
            {
                var Bookings = BookingHelper.GetByID(UserID);

                if (Bookings == null)
                {
                    var message = new OutputBaseWithMessage(new Exception("Not Found"));
                    message.ResultCode = 404;
                    return new OkObjectResult(message);
                }

                return new OkObjectResult(Bookings);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("specific")]
        [ProducesResponseType(typeof(BookingOutput), StatusCodes.Status200OK)]
        public IActionResult GetAllBookingByBook([FromQuery] int BookNumber)
        {
            try
            {
                var Bookings = BookingHelper.GetByBookingID(BookNumber);

                if (Bookings == null)
                {
                    var message = new OutputBaseWithMessage(new Exception("Not Found"));
                    message.ResultCode = 404;
                    return new OkObjectResult(message);
                }
                
                return new OkObjectResult(Bookings);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(TicketOutput), StatusCodes.Status200OK)]
        public IActionResult CreateBooking([FromBody] CreateBookingDTO BookingData)
        {

            try
            {
                var message = BookingHelper.Create(BookingData);

                return new OkObjectResult(message);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
        [HttpPatch]
        [Produces("application/json")]
        [ProducesResponseType(typeof(BookingOutput), StatusCodes.Status200OK)]
        public IActionResult UpdateBookingStatus([FromBody] UpdateBookingDTO BookingInfo)
        {

            try
            {
                var header = Request.Headers;
                var message = new OutputBaseWithMessage(new Exception("Invalid Credentials"));
                message.ResultCode = 500;
                
                
                // bila header tidak di provide return invalid credential
                if (!header.ContainsKey("Authorization"))
                {
                    return new OkObjectResult(message);
                }

                // bila header tidak sesuai return invalid credential
                var token = header["Authorization"];
                if (!token.Equals("Admin"))
                {
                    return new OkObjectResult(message);
                }

                var Output = new OutputBaseWithMessage(new Exception(BookingHelper.UpdateStatus(BookingInfo)));

                if (Output.ErrorMessage == "Not Found")
                {
                    Output.ResultCode = 404;
                }

                return new OkObjectResult(Output);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpDelete]
        [Produces("application/json")]
        [ProducesResponseType(typeof(BookingOutput), StatusCodes.Status200OK)]
        public IActionResult CancelBookingStatus([FromBody] CancelBookingDTO BookingID)
        {

            try
            {
                if (BookingID.BookingID == null && BookingID.TicketID==null)
                {
                    throw new Exception("Invalid ID(s)");
                }
                var Output = new OutputBaseWithMessage(new Exception(BookingHelper.Cancel(BookingID)));

                if (Output.ErrorMessage == "Not Found")
                {
                    Output.ResultCode = 404;
                }

                return new OkObjectResult(Output);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
