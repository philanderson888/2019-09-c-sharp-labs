using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace lab_34_API_Northwind.Controllers
{
    public class WorkingCustomersController : ApiController
    {
        public List<Customer> GetWorkingCustomers()
        {
            using (var db = new NorthwindEntities())
            {
                return db.Customers.ToList();
            }
        }
    }
}
