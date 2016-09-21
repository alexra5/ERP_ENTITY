using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using ERP.Entity;

namespace ERP.Logic.Interface
{

    interface ICustomer : ILogic<Customer> //<T>:IDisposable  where T : class
    {
        void ActualizaOtroDato();
        //Es un ejemplo de como nos servira el ListTo con Lamda
        List<Customer> ClienteConA();
        Customer Find(int id);

    }
}
