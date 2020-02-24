using CSharpandEntityFrameworkLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CSharpandEntityFrameworkLibrary {
    public class AppDbContext : DbContext {

		public AppDbContext() {

		}

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {

		}

		protected override void OnConfiguring(DbContextOptionsBuilder builder) { //add in the functionality of packages (SQl sever/proxies)
			if (!builder.IsConfigured) {
				builder.UseLazyLoadingProxies();
				var connStr = @"server = localhost\sqlexpress; database = CustEfDb; trusted_connection = true;";
				builder.UseSqlServer(connStr);
			}
		}

		protected override void OnModelCreating(ModelBuilder model) { //fluent api
			model.Entity<Product>(e => {
				e.HasKey(x => x.ID); //points to the primary key column
				e.Property(x => x.Code).HasMaxLength(10).IsRequired(); //property is normal columns
				e.Property(x => x.Name).HasMaxLength(30).IsRequired();
				e.Property(x => x.Price);
				e.HasIndex(x => x.Code).IsUnique(); 
				//index is a way to quickly access data; is unique makes it a unique index and forces all data in that row to be unique
			});
		}
							
		public virtual DbSet<Customer> Customers { get; set; } //list of classes that map the tables that your application can access
		public virtual DbSet<Order> Orders { get; set; }
		public virtual DbSet<Product> Products { get; set; }

    }
}
