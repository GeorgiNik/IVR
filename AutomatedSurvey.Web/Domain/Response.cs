namespace AutomatedSurvey.Web.Domain
{
    using System.Collections.Generic;
    using AutomatedSurvey.Web.Models;
    using Twilio.TwiML;

    public class Response
    {
        private readonly Question _question;

        public Response(Question question)
        {
            this._question = question;
        }

        public static IDictionary<QuestionType, string> QuestionTypeToMessage => new Dictionary<QuestionType, string>
        {
            { QuestionType.Voice, "Please record your answer after the beep and then hit the pound sign." },
            { QuestionType.Numeric, "Please press a number between 0 and 9 and then hit the pound sign." },
            { QuestionType.YesNo, "Please press the 1 for yes and the 0 for no and then hit the pound sign." }
        };

        /// <summary>
        /// Builds an instance.
        /// </summary>
        /// <returns>A new instance of the VoiceResponse</returns>
        public VoiceResponse Build()
        {
            var response = new VoiceResponse();
            response.Say(this._question.Body);
            response.Say(QuestionTypeToMessage[this._question.Type]);
            this.AddRecordOrGatherCommands(response);

            return response;
        }

        private static string GenerateUrl(Question question)
        {
            return $"/answers/create?questionId={question.Id}";
        }

        private static string GenerateTranscribeUrl(Question question)
        {
            return $"/answers/update?questionId={question.Id}";
        }

        private void AddRecordOrGatherCommands(VoiceResponse response)
        {
            QuestionType questionType = this._question.Type;
            switch (questionType)
            {
                case QuestionType.Voice:
                    response.Record(action: GenerateUrl(this._question), transcribe: true, playBeep: true, transcribeCallback: GenerateTranscribeUrl(this._question));
                    break;
                case QuestionType.Numeric:
                case QuestionType.YesNo:
                    response.Gather(action: GenerateUrl(this._question), timeout: 30, numDigits: 1);
                    break;
            }
        }
    }
}