namespace AutomatedSurvey.Web.Controllers
{
    using System.Web.Mvc;
    using AutomatedSurvey.Web.Domain;
    using AutomatedSurvey.Web.Models;
    using AutomatedSurvey.Web.Models.Repository;
    using Twilio.AspNet.Mvc;
    using Twilio.TwiML;

    public class AnswersController : TwilioController
    {
        private readonly IRepository<Answer> _answersRepository;
        private readonly IRepository<Question> _questionsRepository;

        public AnswersController()
            : this(new QuestionsRepository(), new AnswersRepository())
        {
        }

        public AnswersController(IRepository<Question> questionsRepository, IRepository<Answer> answersRepository)
        {
            this._questionsRepository = questionsRepository;
            this._answersRepository = answersRepository;
        }

        private static VoiceResponse ExitResponse
        {
            get
            {
                var response = new VoiceResponse();
                response.Say("Thanks for your time. Good bye.");
                response.Hangup();
                return response;
            }
        }

        [HttpPost]
        public ActionResult Update([Bind(Include = "QuestionId,RecordingUrl,CallSid,From,TranscriptionSid,TranscriptionText")] Answer answer)
        {
            Answer answerModel = this._answersRepository.FirstOrDefault(x => x.CallSid == answer.CallSid && x.QuestionId == answer.QuestionId);

            if (answerModel != null)
            {
                answerModel.TranscriptionSid = answer.TranscriptionSid;
                answerModel.TranscriptionText = answer.TranscriptionText;
                this._answersRepository.Update(answerModel);
            }

            return null;
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "QuestionId,RecordingUrl,Digits,CallSid,From")] Answer answer)
        {
            this._answersRepository.Create(answer);

            Question nextQuestion = new QuestionFinder(this._questionsRepository).FindNext(answer.QuestionId);
            VoiceResponse response = nextQuestion != null ? new Response(nextQuestion).Build() : ExitResponse;

            return this.TwiML(response);
        }
    }
}