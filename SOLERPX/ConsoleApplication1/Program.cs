using ERP.Data;
using ERP.Entity;
using ERP.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //////Customer rpt = null;
            //////Customer reg = null;
            //////reg = new Customer() { Nombre = "Alex1", Apellido = "Palacios" };
            
            //////   //using (var rpta = new Repository<Customer>()) 
            //////   using (var rpta = new DCustomer())
            //////    {

            //////    rpt = rpta.Find(a => a.Nombre == reg.Nombre);

            //////        using (var scope = new TransactionScope())
            //////        {
            //////        try
            //////        {
            //////            rpt = rpta.Create(reg);
            //////            reg = null;
            //////            rpt = null;
            //////            reg = new Customer() { Nombre = "Alex5", Apellido = "Martinez5" };
            //////            rpt = rpta.Create(reg);
            //////            reg = null;
            //////            rpt = null;
            //////            reg = new Customer() { Id = 0, Nombre = "Alex6", Apellido = "Martinez6" };
            //////            rpt = rpta.Create(reg);

                        
            //////        }
            //////        catch (Exception)
            //////        {
                     
            //////        }
                    
            //////        //reg = null;
            //////        //reg = new Customer() { Nombre = "Alex2", Apellido = "Martinez2" };
            //////        //rpta.Create(reg);
            //////    }
            //////}
        }
    }
}
