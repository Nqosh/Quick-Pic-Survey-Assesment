using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickPic_Survey_Spa.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string LastChangedBy { get; set; }
        public DateTime LastChangedDate { get; set; }
    }
}