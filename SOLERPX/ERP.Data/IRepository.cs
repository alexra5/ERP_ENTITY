using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ERP.Data
{
    public interface IRepository<T>:IDisposable where T:class
    {
        T Create(T reg);
        bool Update(T reg);
        bool Delete(T reg);
        bool Delete(Expression<Func<T, bool>> exp);
        T Find(Expression<Func<T, bool>> exp);
        T Find(Expression<Func<T, bool>> exp, List<Expression<Func<T, object>>> listexp);
        List<T> ListTo(Expression<Func<T, bool>> exp);
        List<T> ListTo(Expression<Func<T, bool>> exp, List<Expression<Func<T, object>>> listexp);
    }

}
