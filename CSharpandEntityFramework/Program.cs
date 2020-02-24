using CSharpandEntityFrameworkLibrary;
using CSharpandEntityFrameworkLibrary.Models;
using System;
using System.Linq;

namespace CSharpandEntityFramework {
    class Program {
        static void Main(string[] args) {

            var context = new AppDbContext();
            //AddCustomer(context);
            //GetCustomersByPK(context);
            DeleteCustomer(context);
            UpdateCustomer(context);
            GetAllCustomers(context);
        }

        static void UpdateCustomer(AppDbContext context) {
            var custpk = 3;
            var cust = context.Customers.Find(custpk);
            if (cust == null) throw new Exception("Customer not found for update");
            cust.Name = "Meijer";
            var rowsAffected = context.SaveChanges();
            if (rowsAffected != 1) throw new Exception("Failed to update customer");
            Console.WriteLine("Update Successful");
        }

        static void DeleteCustomer(AppDbContext context) {
            var keyToDelete = 4;
            var cust = context.Customers.Find(keyToDelete);
            if (cust == null) throw new Exception("Customer not found to delete");
            context.Customers.Remove(cust);
            var rowsAffected = context.SaveChanges();
            if (rowsAffected != 1) throw new Exception("Delete failed");
        }

        static void GetCustomersByPK(AppDbContext context) {
            var custPk = 3;
            var cust = context.Customers.Find(custPk);
            if (cust == null) throw new Exception("Customer not found");
            Console.WriteLine(cust);
        }

        static void GetAllCustomers(AppDbContext context) {
            var custs = context.Customers.ToList();
            foreach(var c in custs) {
                Console.WriteLine(c);
            }
        }
        static void AddCustomer(AppDbContext context) {
            var cust = new Customer {
                ID = 0,
                Name = "Target",
                Sales = 0,
                Active = true
            };
            context.Customers.Add(cust);
            var rowsAffected = context.SaveChanges(); //in order for the table to be modified it is an int for rows affected
            if (rowsAffected == 0) throw new Exception("Add failed!");
            return;
        }

    }
}
