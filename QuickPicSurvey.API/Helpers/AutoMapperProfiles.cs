using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuickPicSurvey.API.Models;
using QuickPicSurvey.API.DTO;

namespace QuickPicSurvey.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Respondent, UserForListDto>();
            CreateMap<Question, QuestionsToReturnDto>();
        }
    }
}
