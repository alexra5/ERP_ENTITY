
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ERP.Entity;
using ERP.Data.Clases;
using System.Transactions;

using ERP.Logic.Interface;


namespace ERP.Logic
{
    public class LCustomer : ICustomer
    {
        DCustomer objDCustomer = null;
        public LCustomer()
        {
            objDCustomer = new DCustomer();
        }
        public Customer Create(Customer reg)
        {
            Customer Result = null;
            
                using (var scope = new TransactionScope())
                {
                    Customer objCustomer = objDCustomer.Find(a => a.Nombre == reg.Nombre);
                    if (objCustomer == null)
                    {
                        Result = objDCustomer.Create(reg);
                        scope.Complete();
                    }
                    else
                    {
                        if (objDCustomer.Delete(reg))
                        {
                            Result = objDCustomer.Create(reg);
                            scope.Complete();
                        }
                    }
                }
            

            return Result;
        }

        public bool Delete(Customer reg)
        {
            bool Result = false;
            using (var scope = new TransactionScope())
            {
                Customer objCustomer = objDCustomer.Find(a => a.Id == reg.Id);

                if (objDCustomer.Delete(reg))
                {
                    Result = true; 
                    scope.Complete();
                }
                
            }

            return Result;
        }

        public void Dispose()
        {
            if (objDCustomer != null) {
                objDCustomer.Dispose();
            }
        }

 
        public bool Update(Customer reg)
        {
            bool Result = false;

            Result = objDCustomer.Update(reg);

            return Result;
        }

        public void ActualizaOtroDato()
        {
            throw new NotImplementedException();
        }


        //Esto no se modifica nunca
        public Customer Find(Expression<Func<Customer, bool>> exp)
        {
            Customer objCustomer = null;

            objCustomer = objDCustomer.Find(exp);

            return objCustomer;

            //throw new NotImplementedException();
        }


        //Esto no se modifica nunca
        public List<Customer> ListTo(Expression<Func<Customer, bool>> exp)
        {
            List<Customer> list = null;
            list = objDCustomer.ListTo(exp);
            return list;

            //throw new NotImplementedException();
        }

        //Es un ejemplo de como nos servira el ListTo con Lamda
        public List<Customer> ClienteConA()
        {
            //Te das cuenta que estamos usando ListTo y le pasamos un parametro o expresion lamda
            //xq no necesariamente la expresion sera un entidad, podria ser un union distinct es decir, la expresion podria ser cual
            //cualquier cosa pero loq ue devuelve si es lo esperado "la lista customer"
            List<Customer> list = null;
            list = ListTo(a=> a.Apellido.Contains("A"));
            return list;
        }


        public Customer Find(int id)
        {
            Customer objCustomer = null;
            objCustomer = objDCustomer.Find(e => e.Id == id);
            return objCustomer;
        }

        public bool Delete(Expression<Func<Customer, bool>> exp)
        {
            bool Result = false;
            Result = objDCustomer.Delete(exp);
            return Result;
        }

        public Customer Find(Expression<Func<Customer, bool>> exp, List<Expression<Func<Customer, object>>> listexp)
        {
            Customer objCustomer = null;
            objCustomer = objDCustomer.Find(exp,listexp);
            return objCustomer;
        }

        public List<Customer> ListTo(Expression<Func<Customer, bool>> exp, List<Expression<Func<Customer, object>>> listexp)
        {
            List<Customer> ListCustomer = null;
            ListCustomer = objDCustomer.ListTo(exp,listexp);
            return ListCustomer;
        }
    }
}
