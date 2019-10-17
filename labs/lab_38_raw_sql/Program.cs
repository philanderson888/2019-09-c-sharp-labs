using System;
using System.Data.Sql;  // TALK TO SQL DIRECT
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace lab_38_raw_sql
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();

        static string connectionstring = null;
        static string connectionstring2 = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Northwind;";
        static void Main(string[] args)
        {

   
            var secret = Environment.GetEnvironmentVariable("SecretPassword");
            connectionstring = $"Data Source=localhost;Initial Catalog=Northwind;Persist Security Info=True; User ID=SA;Password={secret}";



            for (int i = 0; i < 10; i++)
            {
                InsertCustomer();
            }

            UpdateCustomer();

            DeleteCustomer();

            GetCustomers();
        }

        static void GetCustomers() {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                Console.WriteLine(connection.State);
            }


            using (var connection2 = new SqlConnection(connectionstring2))
            {
                connection2.Open();
                Console.WriteLine(connection2.State);


                string sqlquery01 = "select * from customers order by ContactName";
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

                Console.WriteLine($"\nReading all Northwind Customers\n\n");
                customers.ForEach(c => Console.WriteLine($"{c.CustomerID,-10}{c.ContactName,-30}" +
                    $"{c.CompanyName,-30}{c.City}"));

                Console.WriteLine($"\nThere are {customers.Count} customers\n\n");
            }
        }

        static void InsertCustomer() { 
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                var randomCustomerId = GenerateRandomId();
                Console.WriteLine($"New ID is {randomCustomerId}");
                var FixedCustomer = new Customer(randomCustomerId, "Phil", "Sparta", "London", "UK");
                var sqlString = $"INSERT INTO CUSTOMERS (CustomerID,ContactName,CompanyName,City,Country) " +
                    $"VALUES ('{FixedCustomer.CustomerID}','{FixedCustomer.ContactName}','{FixedCustomer.CompanyName}'" +
                    $",'{FixedCustomer.City}','{FixedCustomer.Country}')";
                using (var command = new SqlCommand(sqlString, connection))
                {
                    int affected = command.ExecuteNonQuery();
                    Console.WriteLine($"{affected} rows inserted");
                }
                // insert using PARAMETERS
                // use parameters when taking values from eg form on screen
                // generate new ID
                randomCustomerId = GenerateRandomId();
                Console.WriteLine($"New ID is {randomCustomerId} with Parameters");
                FixedCustomer = new Customer(randomCustomerId, "Phil", "Sparta", "London", "UK");
                sqlString =
                    "INSERT INTO CUSTOMERS (CustomerID,ContactName,CompanyName,City,Country) " +
                    "VALUES(@CustomerID,@ContactName,@CompanyName,@City,@Country)";
                using (var insertWithParameters = new SqlCommand(sqlString, connection))
                {
                    insertWithParameters.Parameters.AddWithValue("@CustomerID", randomCustomerId);
                    insertWithParameters.Parameters.AddWithValue("@ContactName", "Phil");
                    insertWithParameters.Parameters.AddWithValue("@CompanyName", "Sparta");
                    insertWithParameters.Parameters.AddWithValue("@City", "London");
                    insertWithParameters.Parameters.AddWithValue("@Country", "UK");
                    var sqlreader = insertWithParameters.ExecuteReader();
                }

            }
        } 

        static void UpdateCustomer()
        {
            using (var connection = new SqlConnection(connectionstring2))
            {
                connection.Open();
                var customerIdToUpdate = "'ALFKI'";
                var sqlUpdate = $"UPDATE CUSTOMERS SET City='Paris' WHERE CustomerID = {customerIdToUpdate}";
                using (var sqlcommand = new SqlCommand(sqlUpdate, connection))
                {
                    int affected = sqlcommand.ExecuteNonQuery();
                    Console.WriteLine($"Number of records updated : {affected}");
                }
            }
        }

        static void DeleteCustomer() { 
            using (var connection = new SqlConnection(connectionstring2))
            {
                connection.Open();
                // CAUTION : MUST DO A SELECT FIRST TO CONFIRM EXISTS
                var customerIdToDelete = "'Phil1'";
                var sqlDelete = $"DELETE FROM CUSTOMERS WHERE CustomerID = {customerIdToDelete}";
                using (var sqlcommand = new SqlCommand(sqlDelete, connection))
                {
                    int affected = sqlcommand.ExecuteNonQuery();
                    Console.WriteLine($"Number of records deleted : {affected}");
                }
            }
        }

        static string GenerateRandomId()
        {
            // GENERATE RANDOM CHARACTER GENERATOR WITH 5 FIXED CHARACTERS NO NUMBERS
            // FIRST MUST BE LETTER OTHER 4 CAN BE NUMERIC ALSO
            var s = new StringBuilder();
            var random = new Random();
            for (int i = 0; i < 5; i++)
            {
                char c = (char)random.Next(65, 90);
                s.Append(c);
            }
            return s.ToString();
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

        public Customer(string CustomerID, string ContactName,string CompanyName, string City, string Country)
        {
            this.CustomerID = CustomerID;
            this.ContactName = ContactName;
            this.CompanyName = CompanyName;
            this.City = City;
            this.Country = Country;
        }
    }

}
