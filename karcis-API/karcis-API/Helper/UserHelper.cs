using Binus.WS.Pattern.Entities;
using karcis_API.Model;
using karcis_API.Model.DTO;
using karcis_API.Output;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace karcis_API.Helper
{
    public class UserHelper
    {

        public static List<User> GetAllUser(User Credentials)
        {
            var UserData = new List<User>();
            try
            {

                UserData = EntityHelper.Get<User>().ToList();
                return UserData;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }

        }
        private static readonly string RandomlyGeneratedToken = "C606FEC37D12C4825F871A6D5C741877DE73143673C1969A46707D6C8935B0C6";
        private static readonly string issuer = "https://binus.ac.id";
        public static LoginOutput Login(User Credentials)
        {
            var UserData = new User();
            try
            {

                UserData = EntityHelper.Get<User>().ToList()
                    .Where(e => e.UserEmail == Credentials.UserEmail).
                    FirstOrDefault();
                if (UserData == null) throw new Exception("User not found");

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(RandomlyGeneratedToken));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha384Signature);

                var permClaims = new List<Claim>();
                permClaims.Add(new Claim(ClaimTypes.Name, UserData.UserName));
                permClaims.Add(new Claim(ClaimTypes.Email, UserData.UserEmail));
                permClaims.Add(new Claim("phone", UserData.UserPhone));
                permClaims.Add(new Claim("userid", UserData.UserID.ToString()));

                var token = new JwtSecurityToken(issuer,
                    issuer,
                    permClaims,
                    expires: DateTime.Now.AddDays(7),
                    signingCredentials: credentials
                );
                string JWToken = new JwtSecurityTokenHandler().WriteToken(token);
                var User = new LoginOutput()
                {
                    Token = JWToken,
                    UserName = UserData.UserName,
                    UserPassword = UserData.UserPassword,
                    UserPhone = UserData.UserPhone,
                    UserID = UserData.UserID,
                    UserDOB = UserData.UserDOB,
                    UserEmail = UserData.UserEmail,
                    UserRole = UserData.UserRole

                };

                return User;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
            
        }
        public static string Register(UserDTO Credentials)
        {
            try
            {
                var UserData = EntityHelper.Get<User>()
                    .Where(e => e.UserEmail == Credentials.UserEmail)
                    .FirstOrDefault();
                if (UserData != null) throw new Exception("Email Taken");

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(RandomlyGeneratedToken));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha384Signature);

                var permClaims = new List<Claim>();
                permClaims.Add(new Claim(ClaimTypes.Name, Credentials.UserName));
                permClaims.Add(new Claim(ClaimTypes.Email, Credentials.UserEmail));
                permClaims.Add(new Claim(ClaimTypes.DateOfBirth, Credentials.UserDOB));
                permClaims.Add(new Claim("phone", Credentials.UserPhone));
                permClaims.Add(new Claim("password", Credentials.UserPassword));

                var token = new JwtSecurityToken(issuer,
                    issuer,
                    permClaims,
                    expires: DateTime.Now.AddDays(7),
                    signingCredentials: credentials
                );
                string JWToken = new JwtSecurityTokenHandler().WriteToken(token);

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                smtpClient.Credentials = new NetworkCredential("rogerforsendingemail@gmail.com", "A0l1f5j6mnbv");

                //smtpClient.UseDefaultCredentials = true; // uncomment tanpa credentials
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                MailMessage mail = new MailMessage();

                //Setting From , To and CC
                mail.From = new MailAddress("info@karcis.com", "Karcis.com");
                mail.To.Add(new MailAddress(Credentials.UserEmail));
                mail.Body = "Verify Your Email Here: https://localhost:44333/Registry/Verify?Token=" + JWToken;
                mail.Subject = "Karcis.com Email Verification";

                Console.WriteLine(mail.Body);

                smtpClient.Send(mail);

                return "Success";

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        public static JwtSecurityToken validateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(RandomlyGeneratedToken));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha384Signature);

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,
                ValidIssuer = issuer,
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateLifetime = true,
            }, out SecurityToken validatedToken);
            if (validatedToken == null) return null;

            //Check if the token is expired
            if (validatedToken.ValidTo < DateTime.Now)
            {
                return null;
            }
            var newtoken = (JwtSecurityToken)validatedToken;

            return newtoken;

        }
        public static string ValidateEmail(string token)
        {

            try
            {
                var newtoken = validateToken(token);
                if (newtoken.Claims.Count() == 0)
                {
                    throw new Exception("Invalid Token");
                }
                var UserEmail = newtoken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
                var UserName = newtoken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
                var UserDOB = newtoken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.DateOfBirth).Value;
                var UserPhone = newtoken.Claims.FirstOrDefault(x => x.Type == "phone").Value;
                var UserPassword = newtoken.Claims.FirstOrDefault(x => x.Type == "password").Value;

                User newUser = new User() {
                    CreatedAt = DateTime.Now,
                    UserEmail = UserEmail,
                    UserName = UserName,
                    UserDOB = Convert.ToDateTime(UserDOB),
                    UserPhone = UserPhone,
                    UserPassword = UserPassword,
                    
                };

                EntityHelper.Add(newUser);
                return "Successful";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /*
         * Commented By Joshua
         * Date : 10/02/2022
         * Not implemented in App
         * 
        public static string NewPassword(UserDTO Credentials)
        {
            try
            {
                var UserData = EntityHelper.Get<User>().ToList()
                    .Where(e => e.UserEmail == Credentials.UserEmail).
                    FirstOrDefault();
                if (UserData != null)
                {
                    return "Not Found";
                }

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(RandomlyGeneratedToken));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha384Signature);

                var permClaims = new List<Claim>();
                permClaims.Add(new Claim(ClaimTypes.Email, UserData.UserEmail));
 

                var token = new JwtSecurityToken(issuer,
                    issuer,
                    permClaims,
                    expires: DateTime.Now.AddDays(7),
                    signingCredentials: credentials
                );
                string JWToken = new JwtSecurityTokenHandler().WriteToken(token);

                return JWToken;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public static string UpdatePassword(string token, string NewPassword)
        {


            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(RandomlyGeneratedToken));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha384Signature);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = securityKey,
                    ValidIssuer = issuer,
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                }, out SecurityToken validatedToken);
                if (validatedToken == null) return null;
                //Check if the token is expired
                if (validatedToken.ValidTo < DateTime.Now)
                {
                    return null;
                }
                var newtoken = (JwtSecurityToken)validatedToken;


                //Check if the token is valid
                if (newtoken.Claims.Count() == 0)
                {
                    return null;
                }

                var UserEmail = newtoken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;

                var UserData = EntityHelper.Get<User>()
                    .Where(e => e.UserEmail == UserEmail).
                    FirstOrDefault();
                UserData.UserPassword = BCrypt.Net.BCrypt.HashPassword(NewPassword, salt);
                EntityHelper.Update(UserData);
                
                
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