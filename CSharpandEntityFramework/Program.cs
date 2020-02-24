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
            //DeleteCustomer(context);
            //UpdateCustomer(context);
            UpdateCustomerSales(context);
            GetAllCustomers(context);
           //AddOrders(context);
            //GetAllOrders(context);
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
            if (rowsAffected == 0) throw new Exception("Add failed");
            return;
        }

        static void AddOrders (AppDbContext context) {
            var order = new Order { ID = 0, Description = "Frying Pan", Amount = 20, CustomerId = 3};
            var order2 = new Order { ID = 0, Description = "Apples", Amount = 300, CustomerId = 3 };
            var order3 =  new Order { ID = 0, Description = "Red Velvet Cupcakes", Amount = 90, CustomerId = 3 };
            var order4 = new Order { ID = 0, Description = "Gray Bathroom Rugs", Amount = 60, CustomerId = 3 };
            var order5 = new Order { ID = 0, Description = "Cincinnati Coffee Mug", Amount = 40, CustomerId = 3};
            context.AddRange(order, order2, order3, order4, order5);
            var rowsAffected = context.SaveChanges();
            if (rowsAffected != 5) throw new Exception("Add Orders failed");
            Console.WriteLine("All orders added");
        }
        static void GetAllOrders(AppDbContext context) {
            var orders = context.Orders.ToList();
            foreach(var o in orders) {
                Console.WriteLine(o);
            }
        }

       static void UpdateCustomerSales(AppDbContext context) {
            var CustOrderJoin = from c in context.Customers
                                join o in context.Orders
                                on c.ID equals o.CustomerId
                                where c.ID == 3
                                select new { Amount = o.Amount, Customer = c.Name, Order = o.Description};
            var OrderTotal = CustOrderJoin.Sum(c => c.Amount);
            var cust = context.Customers.Find(3);
            cust.Sales = OrderTotal;
            context.SaveChanges();
        }
    }
}
