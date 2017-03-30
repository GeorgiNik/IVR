namespace AutomatedSurvey.Web.Models.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SurveysRepository : IRepository<Survey>
    {
        private readonly AutomatedSurveysContext _context = new AutomatedSurveysContext();

        public void Create(Survey entity)
        {
            throw new NotImplementedException();
        }

        public Survey FirstOrDefault(Func<Survey, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Survey FirstOrDefault()
        {
            return this._context.Surveys.FirstOrDefault();
        }

        public Survey Find(int id)
        {
            return this._context.Surveys.Find(id);
        }

        public IEnumerable<Survey> All()
        {
            throw new NotImplementedException();
        }

        public void Update(Survey entity)
        {
        }
    }
}