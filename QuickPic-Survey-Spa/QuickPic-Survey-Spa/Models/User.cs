using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickPic_Survey_Spa.Models
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string Token { get; set; }

        public bool IsAdmin { get; set; }
    }
}