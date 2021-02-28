namespace Black_Panther_Knives.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model2")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Order_Detail> Order_Detail { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Sub_Category> Sub_Category { get; set; }
        public virtual DbSet<Value> Values { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Account)
                .HasForeignKey(e => e.Acount_fid);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Reviews)
                .WithOptional(e => e.Account)
                .HasForeignKey(e => e.Account_Fid);

            modelBuilder.Entity<Category>()
                .Property(e => e.Discount)
                .HasPrecision(3, 0);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Sub_Category)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.category_fid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Order_Detail)
                .WithRequired(e => e.Order)
                .HasForeignKey(e => e.Order_fid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Discount)
                .HasPrecision(3, 0);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Order_Detail)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.product_fid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Reviews)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.Product_Fid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sub_Category>()
                .Property(e => e.Discount)
                .HasPrecision(3, 0);

            modelBuilder.Entity<Sub_Category>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Sub_Category)
                .HasForeignKey(e => e.Sub_cat_Fid)
                .WillCascadeOnDelete(false);
        }
    }
}
