using Aspose.Gis;
using Aspose.Gis.Formats.Gml;
using Aspose.GIS.Examples.CSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS_for.NET.Layers
{
    public class ReadFeaturesFromGML
    {
        static string dataDir = RunExamples.GetDataDir();

        public static void Run()
        {
            ReadGMLWithoutSpecifyingGMLOptions();

            ReadGMLBySpecifyingGMLOptions();
        }

        private static void ReadGMLWithoutSpecifyingGMLOptions()
        {
            //ExStart: ReadGMLWithoutSpecifyingGMLOptions
            // Case 1: we try to load schema from Internet.
            // first, we create an instance of GmlOptions class.
            GmlOptions options = new GmlOptions
            {
                // In order to read GML layers features description, Aspose.GIS reads XML schema attached to it.
                // Usually, it is specified in GML files root tag as 'schemaLocation' attribute. If it is not, you need to specify GML schema location
                // youself. In this examples we don't specify it (keep it null), so Aspose.GIS will try to read schema location from XML file.
                SchemaLocation = null,
                // 'schemaLocation' may contain references to schemas located on the Internet. In this case, you need to set this property to 'true' in
                // order to allow Aspose.GIS to load schemas from internet.
                // Basically, if you don't mind Aspose.GIS using internet, you can always keep this true.
                LoadSchemasFromInternet = true,
            };

            // then, we pass it to 'VectorLayer.Open'
            Console.WriteLine("from internet loading...");
            using (VectorLayer layer = VectorLayer.Open(dataDir + "file.gml", Drivers.Gml, options))
            {
                foreach (Feature feature in layer)
                {
                    Console.WriteLine(feature.GetValue<string>("attribute"));
                }
            }

            // Case 2: we try to restore the attributes schema by data in file.
            Console.WriteLine("");
            Console.WriteLine("restoration by file data...");
            using (VectorLayer layer = VectorLayer.Open(dataDir + "file.gml", Drivers.Gml, new GmlOptions(){RestoreSchema = true}))
            {
                foreach (Feature feature in layer)
                {
                    Console.WriteLine(feature.GetValue<string>("attribute"));
                }
            }
            //ExEnd: ReadGMLWithoutSpecifyingGMLOptions
        }

        private static void ReadGMLBySpecifyingGMLOptions()
        {
            //ExStart: ReadGMLBySpecifyingGMLOptions
            GmlOptions options = new GmlOptions
            {
                // In this example we specify custom schemaLocation, since there is no 'schemaLocation' in GML file.
                SchemaLocation = "http://www.aspose.com  schema.xsd",
                LoadSchemasFromInternet = false,
            };

            Console.WriteLine("");
            Console.WriteLine("custom schema location...");
            using (VectorLayer layer = VectorLayer.Open(dataDir + "file_without_schema_location.gml", Drivers.Gml, options))
            {
                foreach (Feature feature in layer)
                {
                    Console.WriteLine(feature.GetValue<string>("attribute"));
                }
            }
            //ExEnd: ReadGMLBySpecifyingGMLOptions
        }
    }
}
