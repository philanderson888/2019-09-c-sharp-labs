using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Net;

namespace lab_45_streaming
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();
        static List<Customer> customersFromXML = new List<Customer>();

        static void Main(string[] args)
        {
            var customer01 = new Customer()
            { CustomerID="ALFKI",ContactName="Fred",CompanyName="Sparta",City="Berlin" };
            var customer02 = new Customer()
            { CustomerID = "BOB22", ContactName = "Bob", CompanyName = "Sparta", City = "Berlin" };
            var customer03 = new Customer()
            { CustomerID = "CHAR1", ContactName = "Charles", CompanyName = "Sparta", City = "Berlin" };
            customers.Add(customer01);
            customers.Add(customer02);
            customers.Add(customer03);

            // LIST
            // SERIALISE TO XML, JSON AND BINARY
            var formatter = new SoapFormatter();
            // SAVE TO FILE ('STREAM' TO FILE SYSTEM)
            using (var stream = new FileStream("data.xml", FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(stream, customers);
                
            }
            // RUN CODE AND SEE VISUALLY OUTPUT
            Console.WriteLine(File.ReadAllText("data.xml"));
            // REVERSE PROCESS ==> STREAM BACK AND DESERIALISE DATA
            // OPEN FILE AS A STREAM
            using (var reader = File.OpenRead("data.xml"))
            {
                // deserialise to list 
                customersFromXML = formatter.Deserialize(reader) as List<Customer>;
            }
            // PRINT OUT LIST
            Console.WriteLine("\n\nCustomers from XML\n\n");
            customersFromXML.ForEach(c => { Console.WriteLine($"{c.CustomerID,-15}" +
                $"{c.ContactName,-20}{c.City}"); });


            // REPEAT SIMULATE STREAMING FROM INTERNET
            // SAKE OF TIME : EASY VERSION : SYNCRONOUS (NOT ASYNC)
            var getHTMLdata = WebRequest.Create("https://raw.githubusercontent.com/philanderson888/data/master/Customers.xml");
            getHTMLdata.Proxy = null;   
            // get web response from request to that url
            using (var webresponse = getHTMLdata.GetResponse())
            {
                // stream data in because it could be large file; no idea size
                using (var webstream = webresponse.GetResponseStream())
                {
                    // GET WEB STREAM ABOVE; NOW NEW STREAM TO STREAM TO LOCAL FILE SYSTEM FOR PROCESSING
                    using (var filestream = File.Create("CustomersFromWeb.xml"))
                    {
                        webstream.CopyTo(filestream);
                    }
                }
            }


            using (var reader2 = File.OpenRead("CustomersFromWeb.xml"))
            {
                // deserialise to list 
                customersFromXML = formatter.Deserialize(reader2) as List<Customer>;
            }
            // PRINT OUT LIST
            Console.WriteLine("\n\nCustomers from Web\n\n");
            customersFromXML.ForEach(c => {
                Console.WriteLine($"{c.CustomerID,-15}" +
                            $"{c.ContactName,-20}{c.City}");
            });

        }
    }

    [Serializable]
    public class Customer
    {
      //  [NonSerialized]
        private string NINO;
        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        
        public Customer()
        {
            this.NINO = "ABCD";
        }
    }
}
