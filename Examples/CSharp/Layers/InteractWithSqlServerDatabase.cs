using System;
using System.Data.SqlClient;
using Aspose.Gis;

namespace Aspose.GIS.Examples.CSharp.Layers
{
    public static class InteractWithSqlServerDatabase
    {
        public static void Run()
        {
            // In order to run this examples, please set SQL_SERVER_CONN_STRING environment variable to the SQL Server connection string.
            // Alternatively, you can just assign connection string to the connectionString variable.
            // Connection string should look like "Data Source=<ip>;User ID=<username>;Initial Catalog=<database>;Password=<password>" or
            // "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=<database>;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var connectionString =
                Environment.GetEnvironmentVariable("SQL_SERVER_CONN_STRING") ??
                Environment.GetEnvironmentVariable("SQL_SERVER_CONN_STRING", EnvironmentVariableTarget.Machine);
            if (connectionString == null)
            {
                Console.WriteLine(
                    "In order to run SqlServer examples, please set environment variable SQL_SERVER_CONN_STRING to the SQL Server connection string.");
                return;
            }

            ListSqlServerTables(connectionString);
        }

        public static void ListSqlServerTables(string connectionString)
        {
            // ExStart: ListSqlServerTables

            // First, we create the connection to the SQL Server
            // Then, we pass this connection to Dataset.Open method in order to access tables in the SQL Server.
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var ds = Dataset.Open(connection, Drivers.SqlServer))
                {
                    // Only spatial tables are exported as layers, so the following code will list all tables
                    // that have geometry column.
                    for (int i = 0; i < ds.LayersCount; ++i)
                    {
                        Console.WriteLine(ds.GetLayerName(i));
                    }
                }
            }

            // ExEnd: ListSqlServerTables
        }
    }
}