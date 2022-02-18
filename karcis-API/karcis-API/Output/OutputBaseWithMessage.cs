using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace karcis_API.Output
{
    public class OutputBaseWithMessage
    {

        public OutputBaseWithMessage(Exception ex,int code=200)
        {
            this.ResultCode = code;
            this.ErrorMessage = ex.Message;
        }
        public int ResultCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
