namespace AutomatedSurvey.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Answer
    {
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Index]
        public string CallSid { get; set; }

        public string Digits { get; set; }

        public string From { get; set; }

        public int Id { get; set; }

        public virtual Question Question { get; set; }

        public int QuestionId { get; set; }

        public string RecordingUrl { get; set; }

        public string TranscriptionText { get; set; }

        public string TranscriptionSid { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}