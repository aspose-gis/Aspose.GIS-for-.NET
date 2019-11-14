using Aspose.Gis;
using Aspose.Gis.Geometries;
using Npgsql;
using System;
using System.IO;

namespace Aspose.GIS.Examples.CSharp.Layers
{
    public static class InteractWithPostGisDatabase
    {
        public static void Run()
        {
            // In order to run this examples, please set PG_CONN_STRING environemnt variable to the PostgreSQL connection string.
            // Alternatively, you can just assign connection string to the connectionString variable.
            // Connection string should look like "Host=<ip>;Username=<username>;Password=<password>;Database=<database>";
            var connectionString = Environment.GetEnvironmentVariable("PG_CONN_STRING");
            if (connectionString == null)
            {
                Console.WriteLine(
                    "In order to run PostGIS examples, please set environment variable PG_CONN_STRING to the PostgreSQL connection string.");
                return;
            }

            CreatePostGisTable(connectionString);
            ListPostGisTables(connectionString);
            ExportPostGisTable(connectionString);
        }

        public static void CreatePostGisTable(string postgreSqlConnectionString)
        {
            // ExStart: CreatePostGisTable

            // First, we create the connection to the PostgreSQL with Npgsql library (https://www.nuget.org/packages/Npgsql/)
            using (var connection = new NpgsqlConnection(postgreSqlConnectionString))
            {
                connection.Open();
                // Then, we pass this connection to Dataset.Open method in order to access tables in the PostgreSQL.
                using (var ds = Dataset.Open(connection, Drivers.PostGis))
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

            // ExEnd: CreatePostGisTable
        }

        public static void ListPostGisTables(string postgreSqlConnectionString)
        {
            // ExStart: ListPostGisTables

            // First, we create the connection to the PostgreSQL with Npgsql library (https://www.nuget.org/packages/Npgsql/)
            // Then, we pass this connection to Dataset.Open method in order to access tables in the PostgreSQL.
            using (var connection = new NpgsqlConnection(postgreSqlConnectionString))
            {
                connection.Open();
                using (var ds = Dataset.Open(connection, Drivers.PostGis))
                {
                    // Only spatial tables are exported as layers, so the following code will list all tables
                    // that have geometry column.
                    for (int i = 0; i < ds.LayersCount; ++i)
                    {
                        Console.WriteLine(ds.GetLayerName(i));
                    }
                }
            }

            // ExEnd: ListPostGisTables
        }

        public static void ExportPostGisTable(string postgreSqlConnectionString)
        {
            // ExStart: ExportPostGisTable

            var outputPath = Path.Combine(RunExamples.GetDataDir(), "postgres_out.shp");

            // First, we create the connection to the PostgreSQL with Npgsql library (https://www.nuget.org/packages/Npgsql/)
            // Then, we pass this connection to Dataset.Open method in order to access tables in the PostgreSQL.
            using (var connection = new NpgsqlConnection(postgreSqlConnectionString))
            {
                connection.Open();
                using (var ds = Dataset.Open(connection, Drivers.PostGis))
                {
                    // open table with the name "features_table" in Postgres database and save it to the shapefile.
                    using (var table = ds.OpenLayer("features_table"))
                    {
                        table.SaveTo(outputPath, Drivers.Shapefile);
                    }
                }
            }

            // ExEnd: ExportPostGisTable
        }
    }
}
