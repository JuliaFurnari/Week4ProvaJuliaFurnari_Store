using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Week4Prova_Store.Core.Interfaces;
using Week4Prova_Store.Core.Models;

namespace Week4Prova_Store.EF.Repositories
{
    public class EFCustomerRepository : ICustomerRepository
    {
        private readonly StoreContext ctx;

        public EFCustomerRepository() : this(new StoreContext())
        {

        }

        public EFCustomerRepository(StoreContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(Customer newCustomer)
        {
            if (newCustomer == null)
                return false;

            try
            {
                ctx.Customers.Add(newCustomer);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

  

        public bool Delete(Customer item)
        {
            if (item == null)
                return false;

            try
            {
                var book = ctx.Customers.Find(item.Id);

                if (book != null)
                    ctx.Customers.Remove(book);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Customer> FetchAll()
        {
            try
            {
                return ctx.Customers.ToList();
            }
            catch (Exception)
            {
                return new List<Customer>();
            }
        }

        public Customer GetById(int id)
        {
            if (id <= 0)
                return null;

            return ctx.Customers.Find(id);
        }

        public bool Update(Customer updatedCustomer)
        {
            if (updatedCustomer == null)
                return false;

            try
            {
                ctx.Customers.Update(updatedCustomer);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
