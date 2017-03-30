namespace AutomatedSurvey.Web.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Survey
    {
        public int Id { get; set; }

        public virtual IList<Question> Questions { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }

        [Required]
        public string Title { get; set; }
    }
}