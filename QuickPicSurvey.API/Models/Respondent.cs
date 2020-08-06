using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickPicSurvey.API.Models
{
    public class Respondent
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string LastChangedBy { get; set; }

        public DateTime LastChangedDate { get; set; }

        public ICollection<Question> Questions { get; set; }

    }
}
