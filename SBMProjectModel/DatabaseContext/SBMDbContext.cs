using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBMProjectModel.Models;

namespace SBMProjectModel.DatabaseContext
{
    public partial class SBMDbContext : DbContext
    {
        public SBMDbContext() : base("name=SBMDbContext")
        {

        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<PurchaseDetails> PurchaseDetailses { get; set; }
        public virtual DbSet<CustomerFiles> CustomerFiles { get; set; }
        public virtual DbSet<SupplierFiles> SupplierFiles { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<SalesDetails> SalesDetails { get; set; }

        
    }
}
