namespace AutomatedSurvey.Web.ViewModels
{
    using System.Collections.Generic;
    using AutomatedSurvey.Web.Models;

    public class ResultVM
    {
        public IEnumerable<Answer> Answers { get; set; }

        public List<string> Calls { get; set; }

        public string SurveyName { get; set; }
    }
}