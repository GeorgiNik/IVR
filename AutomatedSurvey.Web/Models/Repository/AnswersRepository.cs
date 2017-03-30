namespace AutomatedSurvey.Web.Models.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class AnswersRepository : IRepository<Answer>
    {
        private readonly AutomatedSurveysContext _context = new AutomatedSurveysContext();

        public void Create(Answer answer)
        {
            this._context.Answers.Add(answer);
            this._context.SaveChanges();
        }

        public Answer FirstOrDefault(Func<Answer, bool> predicate)
        {
            return this._context.Answers.FirstOrDefault(predicate);
        }

        public Answer FirstOrDefault()
        {
            throw new NotImplementedException();
        }

        public Answer Find(int id)
        {
            return this._context.Answers.Find(id);
        }

        public IEnumerable<Answer> All()
        {
            return this._context.Answers.ToList();
        }

        public void Update(Answer answer)
        {
            this._context.Answers.AddOrUpdate(x => x.Id, answer);
            this._context.SaveChanges();
        }
    }
}