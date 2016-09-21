
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Data
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        DbGenericaEntities Context = null;

        public Repository()
        {
            Context = new DbGenericaEntities();
        }
        private DbSet<T> EntitySet
        {
            get { return Context.Set<T>(); }
        }
        public T Create(T reg)
        {
            T Result = null;
            try
            {
                EntitySet.Add(reg);
                Context.SaveChanges();
                Result = reg;
                return Result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool Delete(Expression<Func<T, bool>> exp)
        {
            bool Result = false;
            try
            {
                var entities = EntitySet.Where(exp).ToList();
                entities.ForEach(x => Context.Entry(x).State = EntityState.Deleted);                
                return Result = Context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(T reg)
        {
            bool Result = false;
            try
            {
                EntitySet.Attach(reg);
                EntitySet.Remove(reg);
                Result = Context.SaveChanges() > 0;
                return Result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }

        public T Find(Expression<Func<T, bool>> exp)
        {
            T Result = null;
            List<T> ResultList = null;
            try
            {
                if (exp == null)
                {
                    new Exception("Ingrese expresion");
                }

                ResultList = EntitySet.Where(exp).ToList();

                if (ResultList.Count > 0)
                {
                    Result = ResultList[0];
                }
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Find(Expression<Func<T, bool>> exp, List<Expression<Func<T, object>>> listexp)
        {
            List<string> includelist = new List<string>();
            T Result = null;
            List<T> ResultList = null;
            try
            {
                if (exp == null)
                {
                    new Exception("Ingrese expresion");
                }
                if (listexp == null)
                {
                    new Exception("Ingrese Lista de Expresiones");
                }
                foreach (var item in listexp)
                {
                    MemberExpression body = item.Body as MemberExpression;
                    if (body == null)
                        throw new ArgumentException("El cuerpo debe ser miembro de la expresion");

                    includelist.Add(body.Member.Name);
                }

                DbQuery<T> query = EntitySet;
                includelist.ForEach(x => query = query.Include(x));
                ResultList = query.Where(exp).ToList();

                if (ResultList != null)
                {
                    if (ResultList.Count > 0)
                    {
                        Result = ResultList[0];
                    }
                }
                
                return Result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<T> ListTo(Expression<Func<T, bool>> exp)
        {
            List<T> Result = null;
            try
            {                
                //if (exp == null)
                //{
                //    Result = EntitySet.ToList();
                //}
                //else
                //{
                //    Result = EntitySet.Where(exp).ToList();
                //}

                //return Result;
                return exp == null ? Result = EntitySet.ToList() : Result = EntitySet.Where(exp).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<T> ListTo(Expression<Func<T, bool>> exp, List<Expression<Func<T, object>>> listexp)
        {

            List<string> includelist = new List<string>();

            foreach (var item in listexp)
            {
                MemberExpression body = item.Body as MemberExpression;
                if (body == null)
                    throw new ArgumentException("El cuerpo debe ser miembro de la expresion");

                includelist.Add(body.Member.Name);
            }

            DbQuery<T> query = EntitySet;

            includelist.ForEach(x => query = query.Include(x));

            return (List<T>)query.Where(exp).ToList();

        }

        public bool Update(T reg)
        {
            bool Result = false;
            try
            {
                EntitySet.Attach(reg);
                Context.Entry<T>(reg).State = EntityState.Modified;
                Result = Context.SaveChanges() > 0;
                return Result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
