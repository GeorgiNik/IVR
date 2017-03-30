namespace AutomatedSurvey.Web.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Question
    {
        public virtual IList<Answer> Answers { get; set; }

        [Required]
        public string Body { get; set; }

        public int Id { get; set; }

        public virtual Survey Survey { get; set; }

        public int SurveyId { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }

        [Required]
        public QuestionType Type { get; set; }
    }
}