namespace AutomatedSurvey.Web.Controllers
{
    using System.Web.Mvc;
    using AutomatedSurvey.Web.Domain;
    using AutomatedSurvey.Web.Models;
    using AutomatedSurvey.Web.Models.Repository;
    using Twilio.AspNet.Mvc;
    using Twilio.TwiML;

    public class QuestionsController : TwilioController
    {
        private readonly IRepository<Question> _questionsRepository;

        public QuestionsController()
            : this(new QuestionsRepository())
        {
        }

        public QuestionsController(IRepository<Question> questionsRepository)
        {
            this._questionsRepository = questionsRepository;
        }

        // GET: /questions/find/5
        public ActionResult Find(int id)
        {
            Question question = this._questionsRepository.Find(id);

            if (question == null)
            {
                return this.HttpNotFound();
            }

            VoiceResponse response = new Response(question).Build();
            return this.TwiML(response);
        }
    }
}