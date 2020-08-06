using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickPicSurvey.API.Data;
using QuickPicSurvey.API.DTO;
using QuickPicSurvey.API.Helpers;
using QuickPicSurvey.API.Models;

namespace QuickPicSurvey.API.Controllers
{

    //[ServiceFilter(typeof(LogUserActivity))]
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RespondentController : ControllerBase
    {

        private readonly IRespondentRepository _repo;
        private readonly IMapper _mapper;

        public RespondentController(IRespondentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetQuestions()
        {
           var questionsFromRepo = await  _repo.GetQuestions();
           var questionsToReturn = _mapper.Map<IEnumerable<QuestionsToReturnDto>>(questionsFromRepo);
           return Ok(questionsToReturn);
             
        }

      
        [HttpPost]
        public async Task<IActionResult> SaveRespondentsSurveyDetails(int userId, List<RespondentsDetailsCreationDto> respondentsDetailsCreationDtos)
        {
            var user = await _repo.GetUser(userId);

            if (user.Id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();


            foreach(var item in respondentsDetailsCreationDtos)
            {
                var respondentDetail = _mapper.Map<RespondentResult>(item);
                _repo.Add(respondentDetail);
            }
            if(await _repo.SaveAll())
            {
                return Ok();
            }

            throw new Exception("Saving the respondents Survey failed");
        }
        // GET: RespondentController

    }
}
