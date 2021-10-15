using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Week4Prova_Store.Core.Interfaces;
using Week4Prova_Store.Core.Models;

namespace Week4Prova_Store.EF.Repositories
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly StoreContext ctx;

        public EFOrderRepository() : this(new StoreContext())
        {

        }

        public EFOrderRepository(StoreContext ctx)
        {
            this.ctx = ctx;
        }
        public bool Add(Order newOrder)
        {
           
            if (newOrder == null)
                return false;

            try
            {
                ctx.Orders.Add(newOrder);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    

     

        public bool Delete(Order deleteOrder)
        {
            if (deleteOrder == null)
                return false;

            try
            {
                var book = ctx.Orders.Find(deleteOrder.Id);

                if (book != null)
                    ctx.Orders.Remove(book);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Order> FetchAll()
        {
          
            try
            {
                return ctx.Orders.Include(ord=>ord.Customer).ToList();
            }
            catch (Exception)
            //{
                return new List<Order>();
            }
        }

        public Order GetById(int id)
        {
            if (id <= 0)
                return null;

            return ctx.Orders.Find(id);
            
        }

        public bool Update(Order updatedOrder)
        {
            if (updatedOrder == null)
                return false;

            try
            {
                ctx.Orders.Update(updatedOrder);
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
