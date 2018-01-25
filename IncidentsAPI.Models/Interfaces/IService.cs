using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace IncidentsAPI.Models.Interfaces
{
    public interface IService<T>
    {
        T GetSingle(Func<T, bool> whereCondition);

        bool Add(T entity);

        void Delete(T entity);

        void Update(T entity);

        List<T> GetAll(Func<T, bool> whereCondition, Func<T, bool> orderBy = null);

        List<T> GetAll(Func<T, bool> orderBy = null);

        IQueryable<T> Query(Func<T, bool> whereCondition);

        long Count(Func<T, bool> whereCondition);

        long Count();
    }
}
