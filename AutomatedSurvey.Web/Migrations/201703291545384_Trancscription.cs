namespace AutomatedSurvey.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Trancscription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "TranscriptionText", c => c.String());
            AddColumn("dbo.Answers", "TranscriptionSid", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Answers", "TranscriptionSid");
            DropColumn("dbo.Answers", "TranscriptionText");
        }
    }
}
