using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Week4Prova_Store.Core.Models;

namespace Week4Prova_Store.WCF
{
    [ServiceContract]
    public interface IStoreService
    {
        [OperationContract]
        List<Customer> FetchCustomers();

        [OperationContract]
        bool CreateCustomer(Customer newCustomer);

        [OperationContract]
        bool EditCustomer(Customer editedCustomer);

        [OperationContract]
        bool DeleteCustomer(int idCustomer);

 
    }

  
   
}
