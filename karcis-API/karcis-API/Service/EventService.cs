using Binus.WS.Pattern.Entities;
using Binus.WS.Pattern.Service;
using karcis_API.Helper;
using karcis_API.Model;
using karcis_API.Model.DTO;
using karcis_API.Output;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace karcis_API.Service
{
    [ApiController]
    [Route("event")]
    public class EventService : BaseService
    {
        public EventService(ILogger<BaseService> logger) : base(logger)
        {
        }
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(EventOutput), StatusCodes.Status200OK)]
        public IActionResult GetEvent([FromQuery] string keyword, [FromQuery] bool current)
        {
            var Events = new EventOutput();
            try
            {
                Events.events = EventHelper.GetAll(keyword,current);

                return new OkObjectResult(Events);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        /* Commented by Joshua
         * Date : 12/02/2022
         * For CRUD Event not needed for App
         * 
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(OutputBaseWithMessage), StatusCodes.Status200OK)]
        public IActionResult CreateEvent([FromBody] CreateEventDTO NewEvent)
        {

            var header = Request.Headers;
            var message = new OutputBaseWithMessage(new Exception("Invalid Credentials"));
            message.ResultCode = 500;

            // bila header tidak di provide return invalid credential
            if (!header.ContainsKey("Authorization") || NewEvent.EventData.CreatedBy == null)
            {
                return new OkObjectResult(message);
            }

            // bila header tidak sesuai return invalid credential
            var token = header["Authorization"];
            if (!token.Equals("Admin"))
            {
                return new OkObjectResult(message);
            }

            try
            {
                var Output = new OutputBaseWithMessage(new Exception(EventHelper.Create(NewEvent)));

                return new OkObjectResult(Output);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPatch]
        [Produces("application/json")]
        [ProducesResponseType(typeof(OutputBaseWithMessage), StatusCodes.Status200OK)]
        public IActionResult UpdateEvent([FromBody] CreateEventDTO EventData)
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

            try
            {
                var Output = new OutputBaseWithMessage(new Exception(EventHelper.Update(EventData)));

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
        [ProducesResponseType(typeof(OutputBaseWithMessage), StatusCodes.Status200OK)]
        public IActionResult DeleteEvent([FromQuery] int EventID)
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
            try
            {
                var Output = new OutputBaseWithMessage(new Exception(EventHelper.Delete(EventID)));

                return new OkObjectResult(Output);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
        */
    }
}