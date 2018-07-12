using Aspose.Gis;
using Aspose.GIS.Examples.CSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS_for.NET.Layers
{
    public class ReadingESRIFileGeoDatabaseFileGDB
    {
        static string dataDir = RunExamples.GetDataDir();

        public static void Run()
        {
            IterateOverLayersInFileGdb();

            OpenFileGdbAsLayer();

            OpenShapefileAsDataset();

            ConvertFeaturesFromFileGdbToGeoJson();
        }

        public static void IterateOverLayersInFileGdb()
        {
            //ExStart: IterateOverLayersInFileGdb
            //File GDB is a multi layer format. This example shows how to open File GDB as a dataset (collection of layers) and access layers in it.
            using (var dataset = Dataset.Open(dataDir + "ThreeLayers.gdb", Drivers.FileGdb))
            {
                Console.WriteLine("FileGDB has {0} layers", dataset.LayersCount);
                for (int i = 0; i < dataset.LayersCount; ++i)
                {
                    Console.WriteLine("Layer {0} name: {1}", i, dataset.GetLayerName(i));

                    using (var layer = dataset.OpenLayerAt(i))
                    {
                        Console.WriteLine("Layer has {0} features", layer.Count);
                        foreach (var feature in layer)
                        {
                            Console.WriteLine(feature.Geometry);
                        }
                    }
                    Console.WriteLine("");
                }
            }
            //ExEnd: IterateOverLayersInFileGdb
        }

        public static void OpenFileGdbAsLayer()
        {
            //ExStart:OpenFileGdbAsLayer
            //FileGDB can still be opened as a single layer. In this case, the opened layer will merge all layers inside FileGDB.
            using (var layer = VectorLayer.Open(dataDir + "ThreeLayers.gdb", Drivers.FileGdb))
            {
                Console.WriteLine("All layers in FileGDB has {0} features", layer.Count);
                foreach (var feature in layer)
                {
                    Console.WriteLine(feature.Geometry);
                }
            }

            //ExEnd: OpenFileGdbAsLayer
        }


        public static void OpenShapefileAsDataset()
        {
            //ExStart: OpenShapefileAsDataset
            //By the moment the only multi layer file format we support is FileGDB. But you can open files of other formats as datasets. 
            //In this case, the dataset will have one layer.
            using (var dataset = Dataset.Open(dataDir +  "PolygonShapeFile.shp", Drivers.Shapefile))
            {
                Console.WriteLine(dataset.LayersCount); // 1
                Console.WriteLine(dataset.GetLayerName(0)); // "point"

                using (var layer = dataset.OpenLayerAt(0))
                // this 'using' is equivalent to
                // using(var layer = VectorLayer.Open("point.shp", Drivrs.Shapefile))
                {
                    foreach (var feature in layer)
                    {
                        Console.WriteLine(feature.Geometry);
                    }
                }
            }
            //ExEnd: OpenShapefileAsDataset
        }

        public static void ConvertFeaturesFromFileGdbToGeoJson()
        {
            File.Delete(dataDir + "ThreeLayers_out.json");
            //ExStart: ConvertFeaturesFromFileGdbToGeoJson
            //This will convert FileGDB dataset with three layers into single layered GeoJSON.
            VectorLayer.Convert(dataDir + "ThreeLayers.gdb", Drivers.FileGdb, dataDir + "ThreeLayers_out.json", Drivers.GeoJson);
            //ExEnd: ConvertFeaturesFromFileGdbToGeoJson
        }
    }
}
