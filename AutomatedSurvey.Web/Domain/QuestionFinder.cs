namespace AutomatedSurvey.Web.Domain
{
    using AutomatedSurvey.Web.Models;
    using AutomatedSurvey.Web.Models.Repository;

    public class QuestionFinder
    {
        private readonly IRepository<Question> _repository;

        public QuestionFinder(IRepository<Question> repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Finds the next question.
        /// </summary>
        /// <param name="questionId">The question ID</param>
        /// <returns>The next question if available, otherwise null</returns>
        public Question FindNext(int questionId)
        {
            Question currentQuestion = this._repository.Find(questionId);
            int nextQuestionId = questionId + 1;

            return this._repository.FirstOrDefault(q => q.SurveyId == currentQuestion.SurveyId && q.Id == nextQuestionId);
        }
    }
}