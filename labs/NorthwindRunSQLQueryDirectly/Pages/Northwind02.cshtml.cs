using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Text;

namespace NorthwindRunSQLQueryDirectly.Pages
{
    public class Northwind02Model : PageModel
    {
        public static List<Customer> customers = new List<Customer>();
        static string connectionstring = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Northwind;";

        public void OnGet()
        {
            using (var connection2 = new SqlConnection(connectionstring))
            {
                connection2.Open();
                Console.WriteLine(connection2.State);


                string sqlquery01 = "select * from customers order by CustomerID";
                using (var sqlcommand = new SqlCommand(sqlquery01, connection2))
                {
                    // read customers on a loop
                    var reader = sqlcommand.ExecuteReader();
                    while (reader.Read())
                    {
                        var CustomerID = reader["CustomerID"].ToString();
                        var ContactName = reader["ContactName"].ToString();
                        var CompanyName = reader["CompanyName"].ToString();
                        var City = reader["City"].ToString();
                        var Country = reader["Country"].ToString();
                        // new customer
                        var customer = new Customer(CustomerID, ContactName, CompanyName, City, Country);
                        // add customer to list of customers
                        customers.Add(customer);
                    }
                }
            }
        }
    }

    public class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public Customer(string CustomerID, string ContactName, string CompanyName, string City, string Country)
        {
            this.CustomerID = CustomerID;
            this.ContactName = ContactName;
            this.CompanyName = CompanyName;
            this.City = City;
            this.Country = Country;
        }
    }
}