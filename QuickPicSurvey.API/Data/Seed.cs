using System;
using QuickPicSurvey.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace QuickPicSurvey.API.Data
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedUsers()
        {
            var respondentsData = System.IO.File.ReadAllText("Data/RespondentSeedData.json");
            var questionsData = System.IO.File.ReadAllText("Data/QuestionSeedData.json");
            var objectiveData = System.IO.File.ReadAllText("Data/ObjectiveSeedData.json");
            var respondentRes = System.IO.File.ReadAllText("Data/RespondentsResultExample.json");

            var respondents = JsonConvert.DeserializeObject<List<Respondent>>(respondentsData);

            var questions = JsonConvert.DeserializeObject<List<Question>>(questionsData);

            var objectives = JsonConvert.DeserializeObject<List<Objective>>(objectiveData);

            var results = JsonConvert.DeserializeObject<List<RespondentResult>>(respondentRes);

            foreach (var rep in respondents)
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash("password", out passwordHash, out passwordSalt);
                rep.PasswordHash = passwordHash;
                rep.PasswordSalt = passwordSalt;
                rep.LastChangedBy = "NMoyo";
                rep.LastChangedDate = DateTime.Now;
                rep.Username = rep.Username.ToLower();
                _context.Respondents.Add(rep);

            }


            foreach (var question in questions)
            {
                question.LastChangedBy = "NMoyo";
                question.LastChangedDate = DateTime.Now;
                _context.Questions.Add(question);
            }

            _context.SaveChanges();

            foreach (var objective in objectives)
            {
                var question = _context.Questions.FirstOrDefault(x => x.Description.Contains(objective.Question));
                if (question != null)
                {
                    objective.QuestionID = question.Id;
                }
                _context.Objectives.Add(objective);
            }

            foreach(var res in results)
            {
               
                _context.RespondentResults.Add(res);
            }

            _context.SaveChanges();
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }


    }
}
