using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace FinalProject.Models
{
    public partial class UserContext:DbContext 
    {
        public UserContext()
         : base("name=UserContext")
        { }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<genMainSlider> GenMainSliders { get; set; }
        public virtual DbSet<genPromoRight> GenPromoRights { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ShippingDetail> ShippingDetails { get; set; }
        public virtual DbSet<RecentlyView> RecentlyViews { get; set; }
        public virtual DbSet<Wishlist> Wishlists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>()
                .Property(e => e.Review1)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .HasKey<int>(e => e.OrderDetailsID);

            modelBuilder.Entity<OrderDetail>()
                .HasKey<int>(e => e.ProductID);


            modelBuilder.Entity<OrderDetail>()
                .Property<decimal>(e => e.UnitPrice);
                

            modelBuilder.Entity<Order>()
                .HasKey<int>(e => e.OrderID);


            modelBuilder.Entity<Order>()
                .HasKey<int>(e => e.CustomerID);
              
            modelBuilder.Entity<Order>()
                .Property(e => e.OrderDate)
                .HasColumnType("datetime");
               
            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .HasKey<int>(e => e.SupplierID);
                
            modelBuilder.Entity<Supplier>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasKey<int>(e => e.ProductID);
        
            modelBuilder.Entity<Product>()
                .Property(e => e.Size)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.UnitPrice);

            modelBuilder.Entity<Product>()
                .HasKey<int>(e => e.CategoryID);
                

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

          
        }
    }
}
