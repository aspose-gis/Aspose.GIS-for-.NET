using System;
using System.Data.SqlClient;
using System.IO;
using Aspose.Gis;
using Aspose.Gis.Geometries;
using Npgsql;

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

            RemoveSqlServerTable(connectionString);
            CreateSqlServerTable(connectionString);
            ListSqlServerTables(connectionString);
            ExportSqlServerTable(connectionString);
        }

        public static void RemoveSqlServerTable(string connectionString)
        {
            // ExStart: RemoveSqlServerTable

            // First, we create the connection to the SQL Server.
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Then, we pass this connection to Dataset.Open method in order to access tables in the SQL Server.
                using (var ds = Dataset.Open(connection, Drivers.SqlServer))
                {
                    // remove table with the name "features_table".
                    // It possible remove a table with geospatial data only.
                    // An exception isn't thrown if the table doesn't exist.
                    ds.RemoveLayer("features_table");
                }
            }

            // ExEnd: RemoveSqlServerTable
        }

        public static void CreateSqlServerTable(string connectionString)
        {
            // ExStart: CreateSqlServerTable

            // First, we create the connection to the SQL Server.
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Then, we pass this connection to Dataset.Open method in order to access tables in the SQL Server.
                using (var ds = Dataset.Open(connection, Drivers.SqlServer))
                {
                    // create table with the name "features_table" and fill it with data.
                    using (var layer = ds.CreateLayer("features_table"))
                    {
                        layer.Attributes.Add(new FeatureAttribute("name", AttributeDataType.String) { Width = 50 });

                        var feature = layer.ConstructFeature();
                        feature.SetValue("name", "Name1");
                        feature.Geometry = Geometry.FromText("POINT (10 20 30)");
                        layer.Add(feature);

                        feature = layer.ConstructFeature();
                        feature.SetValue("name", "Name2");
                        feature.Geometry = Geometry.FromText("POINT (-10 -20 -30)");
                        layer.Add(feature);
                    }
                }
            }

            // ExEnd: CreateSqlServerTable
        }

        public static void ListSqlServerTables(string connectionString)
        {
            // ExStart: ListSqlServerTables

            // First, we create the connection to the SQL Server.
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Then, we pass this connection to Dataset.Open method in order to access tables in the SQL Server.
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

        public static void ExportSqlServerTable(string connectionString)
        {
            // ExStart: ExportSqlServerTable

            var outputPath = Path.Combine(RunExamples.GetDataDir(), "sql_server_out.kml");

            // First, we create the connection to the SQL Server.
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Then, we pass this connection to Dataset.Open method in order to access tables in the SQL Server.
                using (var ds = Dataset.Open(connection, Drivers.SqlServer))
                {
                    // open table with the name "features_table" in SQL Server database and save it to the Kml.
                    using (var table = ds.OpenLayer("features_table"))
                    {
                        table.SaveTo(outputPath, Drivers.Kml);
                    }
                    Console.WriteLine("\nExport complete: " + outputPath);
                }
            }

            // ExEnd: ExportSqlServerTable
        }
    }
}