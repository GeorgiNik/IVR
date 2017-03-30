namespace AutomatedSurvey.Web.Models.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class QuestionsRepository : IRepository<Question>
    {
        private readonly AutomatedSurveysContext _context = new AutomatedSurveysContext();

        public void Create(Question question)
        {
            this._context.Questions.Add(question);
            this._context.SaveChanges();
        }

        public Question FirstOrDefault(Func<Question, bool> predicate)
        {
            return this._context.Questions.FirstOrDefault(predicate);
        }

        public Question FirstOrDefault()
        {
            throw new NotImplementedException();
        }

        public Question Find(int id)
        {
            return this._context.Questions.Find(id);
        }

        public IEnumerable<Question> All()
        {
            return this._context.Questions.ToList();
        }

        public void Update(Question entity)
        {
        }
    }
}