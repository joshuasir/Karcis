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
    [Route("ticket")]
    public class TicketService : BaseService
    {
        public TicketService(ILogger<BaseService> logger) : base(logger)
        {
        }
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(TicketOutput), StatusCodes.Status200OK)]
        public IActionResult GetTicketQuantity([FromQuery] string EventName)
        {
            try
            {
                var ticket_count = TicketHelper.GetAvailable(EventName);
                return new OkObjectResult(ticket_count);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpGet]
        [Route("order")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Ticket), StatusCodes.Status200OK)]
        public IActionResult GetSpecificTicket([FromBody] int TicketID)
        {
            try
            {
                var ticket = TicketHelper.GetSpecific(TicketID);
                return new OkObjectResult(ticket);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpGet]
        [Route("specific")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(TicketOutput), StatusCodes.Status200OK)]
        public IActionResult GetSpecificBooking([FromQuery] int BookingID)
        {
            try
            {
                var ticket = TicketHelper.GetSpecificByBooking(BookingID);
                return new OkObjectResult(ticket);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }


    }
}