using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickPicSurvey.API.Data;

namespace QuickPicSurvey.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {

        private readonly IRespondentRepository _repo;
        private readonly IMapper _mapper;

        public AdminController(IRespondentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: AdminController
        [HttpGet]
        public IActionResult GetRespondentResults()
        {
            var respondentResultsFromRepo = _repo.GetRespondentResults();
            return Ok(respondentResultsFromRepo);
        }
    }
}
