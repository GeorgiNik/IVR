namespace AutomatedSurvey.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using AutomatedSurvey.Web.Models;
    using AutomatedSurvey.Web.Models.Repository;
    using AutomatedSurvey.Web.ViewModels;
    using Twilio.AspNet.Mvc;
    using Twilio.TwiML;

    public class SurveysController : TwilioController
    {
        private readonly IRepository<Answer> _answersRepository;
        private readonly IRepository<Survey> _surveysRepository;

        public SurveysController()
            : this(new SurveysRepository(), new AnswersRepository())
        {
        }

        public SurveysController(
            IRepository<Survey> surveysRepository, IRepository<Answer> answersRepository)
        {
            this._surveysRepository = surveysRepository;
            this._answersRepository = answersRepository;
        }

        [HttpPost]
        public TwiMLResult Welcome()
        {
            var response = new VoiceResponse();
            var gather = new Gather(action: this.Url.Action("Menu", "Surveys"), numDigits: 1, timeout: 20);

            gather.Say("Welcome to code runners test IVR. Thank you for calling code runners.", language: "en-GB");
            gather.Pause(1);
            gather.Say("To hear the survey, press one.", language: "en-GB");
            gather.Pause(2);
            gather.Say("To exit,press two.", language: "en-GB");

            response.Gather(gather);

            return this.TwiML(response);
        }


        // GET: connectcall
        public TwiMLResult StartSurvey()
        {
            var response = new VoiceResponse();
            Survey survey = this._surveysRepository.FirstOrDefault();
            string welcomeMessage = $"Thank you for taking the {survey.Title} survey.";

            response.Say(welcomeMessage);
            response.Redirect(this.Url.Action("find", "questions", new { id = 1 }));

            return this.TwiML(response);
        }

        // GET: surveys/results
        public ActionResult Results()
        {
            IEnumerable<Answer> answers = this._answersRepository.All();
            List<string> uniqueAnswers = answers
                .Select(answer => answer.CallSid)
                .Distinct().ToList();

            var vm = new ResultVM()
            {
                Calls = uniqueAnswers,
                Answers = answers,
                SurveyName = answers.FirstOrDefault()?.Question.Survey.Title
            };

            return this.View(vm);
        }

        [HttpPost]
        public ActionResult Menu(string digits)
        {
            switch (digits)
            {
                case "1": return this.StartSurvey();
                case "2": return this.Exit();
            }

            return this.RedirectWelcome();
        }

        public TwiMLResult Exit()
        {
            var response = new VoiceResponse();
            response.Say("Thank you for your time.", language: "en-GB");
            response.Hangup();

            return this.TwiML(response);
        }

        private TwiMLResult RedirectWelcome()
        {
            var response = new VoiceResponse();
            response.Redirect(this.Url.Action("Welcome", "Surveys"));

            return this.TwiML(response);
        }
    }
}