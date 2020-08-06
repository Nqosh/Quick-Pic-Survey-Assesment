using Microsoft.EntityFrameworkCore;
using QuickPicSurvey.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace QuickPicSurvey.API.Data
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Survey.db");
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DataContext()
        {
        }

        public DbSet<Respondent> Respondents { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Objective> Objectives { get; set; }

        public DbSet<RespondentResult>  RespondentResults { get; set; }

    }
}
