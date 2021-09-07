using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YourPriorityWebApi.Models
{
    public class EmailBody
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Regarding { get; set; }
        public string Office { get; set; }
        public string Refference { get; set; }
        public string Message { get; set; }
    }
}