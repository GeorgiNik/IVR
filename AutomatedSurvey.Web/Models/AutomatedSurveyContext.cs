namespace AutomatedSurvey.Web.Models
{
    using System.Data.Entity;

    public class AutomatedSurveysContext : DbContext
    {
        public AutomatedSurveysContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Survey> Surveys { get; set; }
    }
}