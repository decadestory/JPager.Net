using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JPager.Net.Web.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Age { get; set; }
        public int Score { get; set; }
        public DateTime AddTime { get; set; }
    }
}