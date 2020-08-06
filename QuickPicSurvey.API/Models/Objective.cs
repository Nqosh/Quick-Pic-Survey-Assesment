using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickPicSurvey.API.Models
{
    public class Objective
    {
        public int Id { get; set; }
        public int Expectation { get; set; }
        public int QuestionID { get; set; }

        public string Question { get; set; }
    }
}
