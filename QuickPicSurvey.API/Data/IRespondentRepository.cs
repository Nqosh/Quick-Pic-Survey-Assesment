using QuickPicSurvey.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickPicSurvey.API.Data
{
   public interface IRespondentRepository
    {
        void Add<T>(T entity) where T : class;

        Task<bool> SaveAll();

        Task<Respondent> GetUser(int id);

       Task<IEnumerable<Question>> GetQuestions();

        IEnumerable<RespondentResult> ResultsToReturn();
        IEnumerable<AdminRespondentResult> GetRespondentResults();
    }
}
