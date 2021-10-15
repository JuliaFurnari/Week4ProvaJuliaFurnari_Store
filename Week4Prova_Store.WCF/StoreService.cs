using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Week4Prova_Store.Core.BusinessLayer;
using Week4Prova_Store.Core.Interfaces;
using Week4Prova_Store.Core.Models;
using Week4Prova_Store.EF.Repositories;

namespace Week4Prova_Store.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class StoreService:IStoreService
    {
        private IMainBusinessLayer mainBL;
        public StoreService()
        {
            mainBL = new MainBL(new EFOrderRepository(), new EFCustomerRepository());
        }
        public bool CreateCustomer(Customer newCustomer)
        {
            if (newCustomer == null)
                return false;

            return mainBL.CreateCustomer(newCustomer);
        }

        public bool DeleteCustomer(int idCustomer)
        {
            if (idCustomer > 0)
                return mainBL.DeleteCustomer(idCustomer);

            return false;
        }

        public bool EditCustomer(Customer editedCustomer)
        {
            if (editedCustomer == null)
                return false;

            return mainBL.EditCustomer(editedCustomer);
        }

        public List<Customer> FetchCustomers()
        {
            return mainBL.FetchCustomers();
        }

       
    }
}
