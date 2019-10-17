using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_23_LINQ
{
    class Program
    {
        static List<Customer> customers;
        static void Main(string[] args)
        {

#if DEBUG
            Console.WriteLine("We are in debug mode");
#endif

            using (var db = new NorthwindEntities())
            {
                customers = db.Customers.ToList();
                db.Orders.ToList();
                db.Order_Details.ToList();

                // cannot print this #
                // LINQ produces output of type IQueryable 
                // this is an abstract type so we cast it to a list
                var allCustomers =
                    (from customer in db.Customers
                     orderby customer.City
                     select customer).ToList();
                Console.WriteLine("\n\nTrivial LINQ query : all customers\n");
                PrintCustomers(allCustomers);



                Console.WriteLine("\n\nLINQ where City is London or Berlin\n");
                var LINQwhere =
                    (from customer in db.Customers
                     where customer.City == "London" || customer.City == "Berlin"
                     select customer).ToList();
                PrintCustomers(LINQwhere);

                Console.WriteLine("\n\nOrder By Customer Name\n");
                var LINQOrderBy =
                    (from customer in db.Customers
                     where customer.City == "London"
                     orderby customer.ContactName descending
                     select customer).ToList();
                PrintCustomers(LINQOrderBy);

                Console.WriteLine("\n\nLambda has OrderBy..ThenBy\n");
                var LINQOrderByThenBy =
                    db.Customers.Where(
                        c => c.City == "London" || c.City == "Berlin" ||
                        c.City == "Madrid")
                    .OrderBy(c => c.City)
                    .ThenBy(c => c.ContactName)
                    .ToList();
                PrintCustomers(LINQOrderByThenBy);


                Console.WriteLine("\n\nCreating A Custom Output Object\n");
                var customObject =
                    from c in db.Customers
                    where c.City == "Berlin"
                    join order in db.Orders
                        on c.CustomerID equals order.CustomerID
                    select new
                    {
                        Name = c.ContactName,
                        OrderID = order.OrderID,
                        OrderDate = order.OrderDate,
                        City = order.ShipCity
                    };
                // manual print
                customObject.ToList().ForEach(item => Console.WriteLine($"" +
                    $"{item.Name,-20}{item.OrderID,-10}{item.OrderDate:dd/MM/yyyy}  {item.City}"));


                Console.WriteLine("\n\nJoining Orders To Customers Using Lambda\n");
                // select all orders and put in a list.
                // but before create the list, filter it
                // run through the list and for every order, find the customer (joined by CustomerID)
                // for this order and check their city is berlin.
                db.Orders.Where(o => o.Customer.City == "Berlin").ToList().ForEach(o =>
                {
                    // print customer name, city, orderID, OrderDate
                    Console.WriteLine($"{o.Customer.ContactName,-20}{o.Customer.City,-15}" +
                        $"{o.OrderID,-15}{o.OrderDate:dd/MM/yyyy}");
                });


                Console.WriteLine("\n\nJoining 3 tables : Order Details, Orders, Customers\n");
                db.Order_Details.Where(od => od.Order.Customer.City == "Berlin").ToList()
                    .ForEach(od =>
                    {
                        Console.WriteLine($"{od.Order.Customer.ContactName,-20}" +
                            $"{od.Order.Customer.City,-15}" +
                            $"{od.OrderID,-15}" +
                            $"{od.ProductID,-10}" +
                            $"{od.Order.OrderDate:dd/MM/yyyy}");

                    });

                Console.WriteLine("\n\nJoining 4 tables: Order Details, Orders, Products, Customers\n");
                db.Order_Details.Where(od => od.Order.Customer.City == "Berlin").ToList()
                    .ForEach(od =>
                    {
                        Console.WriteLine($"{od.Order.Customer.ContactName,-20}" +
                            $"{od.Order.Customer.City,-15}" +
                            $"{od.OrderID,-15}" +
                            $"{od.ProductID,-10}" +
                            $"{od.Product.ProductName,-30}" +
                            $"{od.Order.OrderDate:dd/MM/yyyy}");
                    });
            }
        }

#region PrintBlock
        static void PrintCustomers(List<Customer> customers)
        {
            // find max length of name
            var maxCustomerNameLength = customers.Max(c => c.ContactName.Length)+1;

            customers.ForEach(c => Console.WriteLine($"{c.CustomerID.PadRight(10)}" +
                $"{c.ContactName.PadRight(maxCustomerNameLength)}" +
                $"{c.Address,-30}{c.City,-15}{c.Country}"));
        }
#endregion PrintBlock
    }
}
