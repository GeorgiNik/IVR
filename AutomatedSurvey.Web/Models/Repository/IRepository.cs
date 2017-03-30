namespace AutomatedSurvey.Web.Models.Repository
{
    using System;
    using System.Collections.Generic;

    public interface IRepository<T>
    {
        void Create(T entity);

        void Update(T entity);

        T FirstOrDefault(Func<T, bool> predicate);

        T FirstOrDefault();

        T Find(int id);

        IEnumerable<T> All();
    }
}