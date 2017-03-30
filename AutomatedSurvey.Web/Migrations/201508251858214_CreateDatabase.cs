namespace AutomatedSurvey.Web.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                             "dbo.Answers",
                             c => new
                             {
                                 Id = c.Int(nullable: false, identity: true),
                                 RecordingUrl = c.String(),
                                 Digits = c.String(),
                                 CallSid = c.String(maxLength: 50, unicode: false),
                                 From = c.String(),
                                 Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                                 QuestionId = c.Int(nullable: false)
                             })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.CallSid)
                .Index(t => t.QuestionId);

            this.CreateTable(
                             "dbo.Questions",
                             c => new
                             {
                                 Id = c.Int(nullable: false, identity: true),
                                 Body = c.String(nullable: false),
                                 Type = c.Int(nullable: false),
                                 Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                                 SurveyId = c.Int(nullable: false)
                             })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Surveys", t => t.SurveyId, cascadeDelete: true)
                .Index(t => t.SurveyId);

            this.CreateTable(
                             "dbo.Surveys",
                             c => new
                             {
                                 Id = c.Int(nullable: false, identity: true),
                                 Title = c.String(nullable: false),
                                 Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion")
                             })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            this.DropForeignKey("dbo.Questions", "SurveyId", "dbo.Surveys");
            this.DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            this.DropIndex("dbo.Questions", new[] { "SurveyId" });
            this.DropIndex("dbo.Answers", new[] { "QuestionId" });
            this.DropIndex("dbo.Answers", new[] { "CallSid" });
            this.DropTable("dbo.Surveys");
            this.DropTable("dbo.Questions");
            this.DropTable("dbo.Answers");
        }
    }
}