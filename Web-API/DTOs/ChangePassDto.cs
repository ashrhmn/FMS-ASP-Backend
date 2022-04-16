using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_API.DTOs
{
    public class ChangePassDto
    {
        public string OldPassword { get; set; }
        public string Password { get; set; }
        public string ConPassword { get; set; }
    }
}