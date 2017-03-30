namespace AutomatedSurvey.Web.Migrations
{
    using System.Data.Entity.Migrations;
    using AutomatedSurvey.Web.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<AutomatedSurveysContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AutomatedSurveysContext context)
        {
            context.Surveys.AddOrUpdate(survey => new { survey.Id, survey.Title },
                                        new Survey { Id = 1, Title = "code runners" });

            context.SaveChanges();

            context.Questions.AddOrUpdate(question => new { question.Body, question.Type, question.SurveyId },
                                          new Question
                                          {
                                              Body = "On a scale of 0 to 9 how would you rate code runners?",
                                              Type = QuestionType.Numeric,
                                              SurveyId = 1
                                          },
                                          new Question
                                          {
                                              Body = "In your own words please describe your feelings about Code runners right now? Press the pound sign when you are finished.",
                                              Type = QuestionType.Voice,
                                              SurveyId = 1
                                          },
                                          new Question
                                          {
                                              Body = "On a scale of 0 to 9 how would you rate the quality of this IVR?",
                                              Type = QuestionType.Numeric,
                                              SurveyId = 1
                                          },
                                          new Question
                                          {
                                              Body = "Do you like code runners? Please be honest, I dislike liars.",
                                              Type = QuestionType.YesNo,
                                              SurveyId = 1
                                          });

            context.SaveChanges();
        }
    }
}