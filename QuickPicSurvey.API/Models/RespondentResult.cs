using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickPicSurvey.API.Models
{
    public class RespondentResult
    {

        public int Id { get; set; }

        public int RespondentId { get; set; }

        public int QuestionId { get; set; }

        public int RespondentsWeight { get; set; }
    
    }
}
