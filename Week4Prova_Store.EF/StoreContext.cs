using Microsoft.EntityFrameworkCore;
using System;
using Week4Prova_Store.Core.Models;

namespace Week4Prova_Store.EF
{
    // Progetto WCF come Startup project
    //Progetto EF come default project(nella console package manager)

   //1) Add-Migration NomeMigration
   //2) Update-Database
    public class StoreContext:DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public StoreContext() : base()
        {

        }
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                string connectionString = @"Server = (localdb)\mssqllocaldb; Database = Store; Trusted_Connection = True;";
               
                options.UseSqlServer(connectionString);
            

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //APPLICARE CONFIGURAZIONI
            modelBuilder.ApplyConfiguration<Order>(new OrderConfiguration());
            modelBuilder.ApplyConfiguration<Customer>(new CustomerConfiguration());
        }
    }
}
