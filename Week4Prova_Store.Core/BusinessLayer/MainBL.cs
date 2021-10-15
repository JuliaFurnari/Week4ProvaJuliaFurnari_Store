using System;
using System.Collections.Generic;
using System.Text;
using Week4Prova_Store.Core.Interfaces;
using Week4Prova_Store.Core.Models;

namespace Week4Prova_Store.Core.BusinessLayer
{
    public class MainBL : IMainBusinessLayer
    {
        private readonly IOrderRepository orderRepo;
        private readonly ICustomerRepository customerRepo;

        public MainBL(IOrderRepository orderRepo, ICustomerRepository customerRepo
        )
        {
            this.orderRepo = orderRepo;
            this.customerRepo = customerRepo;
        }

        #region Customers
        public bool CreateCustomer(Customer newCustomer)
        {
            if (newCustomer == null)
                return false;

            //altrimenti
            return customerRepo.Add(newCustomer);
        }
        public List<Customer> FetchCustomers()
        {
            return customerRepo.FetchAll();
        }
        public Customer GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public bool EditCustomer(Customer editedCustomer)
        {
            if (editedCustomer == null)
                return false;

            return customerRepo.Update(editedCustomer);
        }
        public bool DeleteCustomer(int idCustomer)
        {
            if (idCustomer <= 0)
                return false;

            Customer customerToDelete = customerRepo.GetById(idCustomer);

            if (customerToDelete != null)
            {
                bool isDeleted = customerRepo.Delete(customerToDelete);
                return isDeleted;
            }
            return false;
        }


        #endregion

        #region Orders
      
        public bool CreateOrder(Order newOrder)
        {
            if (newOrder == null)
                return false;

            return orderRepo.Add(newOrder);
        }

      

        public bool EditOrder(Order editedOrder)
        {
            if (editedOrder == null)
                return false;

            return orderRepo.Update(editedOrder);
        }

     

        public List<Order> FetchOrders()
        {
            return orderRepo.FetchAll();
        }

    

        public Order GetOrderById(int id)
        {
            if (id <= 0)
                return null;

            return orderRepo.GetById(id);
        }

        public bool DeleteOrder(int idOrder)
        {
            if (idOrder <= 0)
                return false;

            Order orderBeDeleted = this.orderRepo.GetById(idOrder);

            if (orderBeDeleted != null)
                return orderRepo.Delete(orderBeDeleted);

            return false;
        }


        #endregion
    }
}
