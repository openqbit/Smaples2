using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using IJSE.POS.Common.Models;
using IJSE.POS.DataAccess.DAL.Contracts;

namespace IJSE.POS.DataAccess.DAL
{
    public class PosContext : DbContext
    {
        public PosContext() : base("IJSEPosDB") {

            this.Configuration.ProxyCreationEnabled = false;

        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetail { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<ItemDetail> ItemDetail { get; set; }

        public DbSet<SystemUser> SystemUser { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
