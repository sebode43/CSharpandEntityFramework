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
							
		public virtual DbSet<Customer> Customers { get; set; } //list of classes that map the tables that your application can access
		public virtual DbSet<Order> Orders { get; set; }
		public virtual DbSet<Product> Products { get; set; }

    }
}
