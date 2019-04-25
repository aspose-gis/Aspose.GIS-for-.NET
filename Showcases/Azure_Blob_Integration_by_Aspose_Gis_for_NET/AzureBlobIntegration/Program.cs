using System;
using Aspose.Gis;
using Aspose.Gis.Geometries;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AzureBlobIntegration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // This program manipulates the GIS data on the Azure Blob storage.
            // It uses an inheritor of "Aspose.GIS.AbstractPath". If you need to implement your own inheritor of
            // "Aspose.GIS.AbstractPath" to support some external file storage, refer to "AzurePath" class.
            // This program:
            // - crates a GeoJSON layer on the Azure Blob storage;
            // - reads a Shapefile from the Azure Blob storage and prints its geometries;
            // - converts the Shapefile located on the Azure Blob Storage to the KML file located on the same storage.

            // First - we need to get the blob container
            var blobContainer = GetBlobContainer("azureintegrationcontainer");

            // -- Create a GeoJSON Layer in the Azure Blob Storage --
            // Create an instance of 'AzurePath'. 'AzurePath' is an inheritor of 'AbstratPath'
            // and we can use it to make Aspose.GIS work with Azure Blob storage.
            // See the AzurePath class for detailed description on how it works and how you can implement
            // your own inheritor of 'AbstractPath'.
            var geoJsonAzurePath = new AzurePath(blobContainer, "directory/file.json");
            // Delete a geojson file if it exists.
            geoJsonAzurePath.Delete();
            // Create the layer.
            using (var layer = VectorLayer.Create(geoJsonAzurePath, Drivers.GeoJson))
            {
                layer.Attributes.Add(new FeatureAttribute("id", AttributeDataType.Integer));
                var feature = layer.ConstructFeature();
                feature.SetValue("id", 1);
                feature.Geometry = new Point(1, 2);
                layer.Add(feature);

                feature = layer.ConstructFeature();
                feature.SetValue("id", 2);
                feature.Geometry = new Point(3, 4);
                layer.Add(feature);
            }
            var geoJsonText = blobContainer.GetBlockBlobReference("directory/file.json").DownloadText();
            Console.WriteLine("Created GeoJSON:");
            Console.WriteLine(geoJsonText);
            // --

            // There is no way to create a Shapefile via AzurePath, since Shapefile requires write streams to support
            // seeking. We upload the Shapefile from the local file system.
            blobContainer.GetBlockBlobReference("shapefile/point.shp").UploadFromFile("shapefile/point.shp");
            blobContainer.GetBlockBlobReference("shapefile/point.shx").UploadFromFile("shapefile/point.shx");
            blobContainer.GetBlockBlobReference("shapefile/point.dbf").UploadFromFile("shapefile/point.dbf");

            Console.WriteLine("Shapefile Geometries:");
            // -- Read the Shapefile From the Azure Blob Storage -- 
            var shapefileAzurePath = new AzurePath(blobContainer, "shapefile/point.shp");
            using (var layer = VectorLayer.Open(shapefileAzurePath, Drivers.Shapefile))
            {
                foreach (var feature in layer)
                {
                    Console.WriteLine(feature.Geometry.AsText());
                }
            }
            // --
            Console.WriteLine();

            // -- Convert the Shapefile on the Azure Blob Storage to the KML on the Same Storage --
            var kmlAzurePath = new AzurePath(blobContainer, "kml.kml");
            // Delete destination if it already exists
            kmlAzurePath.Delete();
            VectorLayer.Convert(shapefileAzurePath, Drivers.Shapefile, kmlAzurePath, Drivers.Kml);
            // --

            var kmlText = blobContainer.GetBlockBlobReference("kml.kml").DownloadText();
            Console.WriteLine("Converted KML:");
            Console.WriteLine(kmlText);
        }

        private static CloudBlobContainer GetBlobContainer(string containerName)
        {
            // Create cloud blob client
            var connectionString = Environment.GetEnvironmentVariable("azure_blob_connection_string");
            if (!CloudStorageAccount.TryParse(connectionString, out var account))
            {
                Console.WriteLine("A connection string is not defined in the system environment variables.");
                Console.WriteLine("Define an environment variable with name 'azure_blob_connection_string' " +
                                  "with connection string as a value.");
                Environment.Exit(1);
            }

            var client = account.CreateCloudBlobClient();

            // Get blob container.
            var container = client.GetContainerReference(containerName);
            container.CreateIfNotExists();
            return container;
        }
    }
}
