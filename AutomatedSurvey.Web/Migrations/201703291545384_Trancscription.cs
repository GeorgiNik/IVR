namespace AutomatedSurvey.Web.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Trancscription : DbMigration
    {
        public override void Up()
        {
            this.AddColumn("dbo.Answers", "TranscriptionText", c => c.String());
            this.AddColumn("dbo.Answers", "TranscriptionSid", c => c.String());
        }

        public override void Down()
        {
            this.DropColumn("dbo.Answers", "TranscriptionSid");
            this.DropColumn("dbo.Answers", "TranscriptionText");
        }
    }
}