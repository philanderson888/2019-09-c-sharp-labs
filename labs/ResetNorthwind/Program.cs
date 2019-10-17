using System;
using System.IO;
using System.Data.SqlClient;
//using Microsoft.SqlServer.Management.Common;
//using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer;
using Microsoft.SqlServer.Server;
using Microsoft.EntityFrameworkCore.SqlServer;



namespace ResetNorthwind
{
    class Program
    {
        static void Main(string[] args)
        {

            var connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Northwind";

            var installNorthwindScript = File.ReadAllText(@"..\..\..\..\SQL\InstallNorthwind.sql");

              var readcustomers = File.ReadAllText(@"..\..\..\..\SQL\NorthwindQueries-02.sql");



            using (var connection = new SqlConnection(connectionString))
            {

                connection.Open();
                using (var command = new SqlCommand(installNorthwindScript, connection))
                {
                    command.ExecuteNonQuery();
                }

            }



           

        }
    }
}
