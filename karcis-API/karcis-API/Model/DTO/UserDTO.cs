using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace karcis_API.Model.DTO
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string UserDOB { get; set; }
        public string UserPhone { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }
    public class NewPasswordDTO
    {
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}
