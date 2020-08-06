using Microsoft.EntityFrameworkCore;
using QuickPicSurvey.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickPicSurvey.API.Data
{
    public class RespondentRepository : IRespondentRepository
    {
        private DataContext _context;
        public RespondentRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public async Task<Respondent> GetUser(int id)
        {
            var user = await _context.Respondents.FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public Task<bool> SaveAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RespondentResult> ResultsToReturn()
        {
            var results = _context.RespondentResults.ToList();
            return results;
        }

        public async Task<IEnumerable<Question>> GetQuestions()
        {
            var questions = await _context.Questions.ToListAsync();
            return questions;
        }

        public IEnumerable<AdminRespondentResult> GetRespondentResults()
        {
            var respondentRes =  from r in _context.RespondentResults
                                      join o in _context.Objectives
                                      on r.QuestionId equals o.QuestionID
                                      join q in _context.Questions
                                      on r.QuestionId equals q.Id
                                      select new {
                                               r.RespondentId,
                                               r.RespondentsWeight,
                                               o.QuestionID,
                                               q.Description,
                                               o.Expectation };

            AdminRespondentResult adminRespondentResult = new AdminRespondentResult();
            List<AdminRespondentResult> adminRespondentResultList = new List<AdminRespondentResult>();

            foreach(var item in respondentRes)
            {
                adminRespondentResult.QuestionID = item.QuestionID;
                adminRespondentResult.Description = item.Description;
                adminRespondentResult.Expectation = item.Expectation;
                adminRespondentResult.RespondentsWeight = item.RespondentsWeight;
                adminRespondentResult.RespondentId = item.RespondentId;

                adminRespondentResultList.Add(adminRespondentResult);
            }
            return adminRespondentResultList;
        }
    }
}
