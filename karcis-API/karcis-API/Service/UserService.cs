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
    [Route("user")]
    public class UserService : BaseService
    {
        public UserService(ILogger<BaseService> logger) : base(logger)
        {
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("login")]
        [ProducesResponseType(typeof(LoginOutput), StatusCodes.Status200OK)]
        public IActionResult GetUser([FromBody] User Credentials)
        {

            try
            {
                 var UserData = UserHelper.Login(Credentials);

                if (UserData == null)
                {
                    throw new Exception("Not Found");
                }

                return new OkObjectResult(UserData);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("register")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult RegisterUser([FromBody] UserDTO UserData)
        {

            try
            {
                if (UserData == null || UserData.UserEmail == null || UserData.UserPassword == null || UserData.UserName == null || UserData.UserPhone == null)
                {
                    throw new Exception("InvalidParameter");
                }
                var message = UserHelper.Register(UserData);

                return new OkObjectResult(message);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
        /*
         * Commented By Joshua
         * Date : 10/02/2022
         * Not implemented in App
         * 
        [HttpPost]
        [Route("forgot")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult ForgotPassword([FromBody] UserDTO UserData)
        {

            try
            {
                if (UserData.UserEmail == null)
                {
                    throw new Exception("InvalidParameter");
                }
                var Token = UserHelper.NewPassword(UserData);

                return new OkObjectResult(Token);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPatch]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult UpdatePassword([FromBody] NewPasswordDTO NewPasswordInfo )
        {

            try
            {

                var Output = new OutputBaseWithMessage(new Exception(UserHelper.UpdatePassword(NewPasswordInfo.Token, NewPasswordInfo.NewPassword)));

                return new OkObjectResult(Output);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
        */
        [Route("verify")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(OutputBaseWithMessage), StatusCodes.Status200OK)]
        public IActionResult ValidateEmail([FromQuery] string Token)
        {

            try
            {
                var Output = new OutputBaseWithMessage(new Exception(UserHelper.ValidateEmail(Token)));

                return new OkObjectResult(Output);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}