using ERP.Data.Clases;
using ERP.Data.Interface;
using ERP.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ERP.Data.Clases
{
    public class DCustomer:Repository<Customer>, ICustomer   //: IRepository<Customer>
    {
        
        //Este ejemplo podria ser para que ejecute un SP o algo especial
        public void ActualizaOtroDato()
        {
            throw new NotImplementedException();
        }
    }
}
