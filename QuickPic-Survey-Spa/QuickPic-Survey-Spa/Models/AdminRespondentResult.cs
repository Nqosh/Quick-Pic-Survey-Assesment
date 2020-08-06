using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickPic_Survey_Spa.Models
{
    public class AdminRespondentResult
    {
        public int RespondentId { get; set; }
        public int RespondentsWeight { get; set; }

        public int QuestionID { get; set; }

        public string Description { get; set; }

        public int Expectation { get; set; }

        public int ExpectationGap { get; set; }

        public double Accuracy { get; set; }

    }
}