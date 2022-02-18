using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Karcis.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserDOB { get; set; }
        public string UserPhone { get; set; }
        public string UserEmail { get; set; }
        public string Token { get; set; }
        public bool UserRole { get; set; }
    }
}
