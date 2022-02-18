using Binus.WS.Pattern.Output;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace karcis_API.Output
{
    public class LoginOutput
    {
        public int UserID { get; set; }
        public string UserName { get; set; }

        public string UserPassword { get; set; }
        public DateTime? UserDOB { get; set; }
        public string UserPhone { get; set; }
        public string UserEmail { get; set; }

        public bool UserRole { get; set; }
        public string Token { get; set; }
    }
    

}
