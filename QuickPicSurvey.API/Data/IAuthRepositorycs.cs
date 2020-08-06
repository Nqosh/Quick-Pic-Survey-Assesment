using QuickPicSurvey.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickPicSurvey.API.Data
{
    public interface IAuthRepository
    {
        Task<Respondent> Regiser(Respondent user, string password);
        Task<Respondent> Login(string username, string password);
        Task<bool> UserExist(string username);

    }
}
