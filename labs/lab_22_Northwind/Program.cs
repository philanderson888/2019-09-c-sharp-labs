using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_22_Northwind
{
    class Program
    {
        static List<Product> products;
        static void Main(string[] args)
        {
            using (var db = new NorthwindEntities()){
                products = db.Products.ToList();
                db.Suppliers.ToList();
                db.Categories.ToList();
            }

            products.ForEach(p => {
                Console.WriteLine($"{p.ProductID,-10}{p.ProductName,-30}{p.CategoryID,-10}" +
                    $"{p.UnitPrice}");
            });

            // categories


            // Products with catgegory name
            products.ForEach(p => {
                Console.WriteLine($"{p.ProductID,-10}{p.ProductName,-30}{p.Category.CategoryName,-20}" +
                    $"{p.Supplier.CompanyName,-30}{p.UnitPrice}");
            });


        }

    }
}
