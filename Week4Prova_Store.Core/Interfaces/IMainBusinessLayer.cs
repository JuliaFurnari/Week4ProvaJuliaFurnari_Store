using System;
using System.Collections.Generic;
using System.Text;
using Week4Prova_Store.Core.Models;

namespace Week4Prova_Store.Core.Interfaces
{
    public interface IMainBusinessLayer
    {
        #region Orders
        //Metodi per gli ordini
        List<Order> FetchOrders();
        bool CreateOrder(Order newOrder);
        bool EditOrder(Order editedOrder);
        bool DeleteOrder(int idOrder);

        Order GetOrderById(int id);

        #endregion

        #region Customers
        //Metodi per i clienti
        List<Customer> FetchCustomers();
        bool CreateCustomer(Customer newCustomer);
        bool EditCustomer(Customer editedCustomer);
        bool DeleteCustomer(int idCustomer);

        Customer GetCustomerById(int id);
        #endregion
    }
}
