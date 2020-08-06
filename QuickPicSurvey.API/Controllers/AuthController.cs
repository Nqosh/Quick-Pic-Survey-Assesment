using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickPicSurvey.API.Data;
using AutoMapper;
using QuickPicSurvey.API.DTO;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using QuickPicSurvey.API.Models;

namespace QuickPicSurvey.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IRespondentRepository _respondent;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public AuthController(IAuthRepository repo, IRespondentRepository respondent, IConfiguration config, IMapper mapper)
        {
            _repo = repo;
            _config = config;
            _mapper = mapper;
            _respondent = respondent;
        }

        // GET: AuthController

        // GET: AuthController/Details/5
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLogInDto userForLogInDto)
        {

            try
            {
                var userfromRepo = await _repo.Login(userForLogInDto.UserName.ToLower(), userForLogInDto.Password);

                if (userfromRepo == null)
                    return Unauthorized();

                var claims = new[]
                    {
                new Claim(ClaimTypes.NameIdentifier,userfromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name,userfromRepo.Username)
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.
                        GetBytes(_config.GetSection("AppSettings:Token").Value));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = creds

                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);

                UserForListDto user = null;
                bool isAdmin;
                IEnumerable<RespondentResult> respondentResults = null;

                if (userfromRepo.Username == "admin")
                {
                    isAdmin = true;
                    //to do need to get the respondent results 
                    respondentResults =  _respondent.ResultsToReturn();
                }
                else
                {
                    user = _mapper.Map<UserForListDto>(userfromRepo);
                }
                if(userfromRepo.Username == "admin")
                {
                    return Ok(new
                    {
                        token = tokenHandler.WriteToken(token),
                        respondentResults,
                        isAdmin = true
                    });
                }
                else
                {
                    return Ok(new
                    {
                        user,
                        token = tokenHandler.WriteToken(token),
                        isAdmin = false
                    }); ;
                }               
            }
            catch
            {
                return StatusCode(500, "Failed to Validate User");
            }
        }
    
    }
}
