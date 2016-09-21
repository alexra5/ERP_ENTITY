using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ERP.Entity;

namespace ERP.Data.Interface
{
    public interface ICustomer: IRepository<Customer>
    {
        //para ejecutar un sp o algo especial
        void ActualizaOtroDato();
    }
}
