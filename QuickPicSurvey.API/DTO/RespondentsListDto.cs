using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickPicSurvey.API.DTO
{
    public class RespondentsListDto
    {
        public int Id { get; set; }
        public int RespondentId { get;set; }

        public int QuestionId { get; set; }

        public string Description { get; set; }
        public int RespondentsWeight { get; set; }

        public int ManagersWeight { get; set; }
    }
}
