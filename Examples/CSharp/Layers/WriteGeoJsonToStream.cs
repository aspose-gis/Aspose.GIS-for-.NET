using System;
using System.IO;
using System.Text;
using Aspose.Gis;
using Aspose.Gis.Geometries;

namespace Aspose.GIS.Examples.CSharp.Layers
{
    public class WriteGeoJsonToStream
    {
        public static void Run()
        {
            //ExStart: WriteGeoJsonToStream
            using (var memoryStream = new MemoryStream())
            {
                using (var layer = VectorLayer.Create(AbstractPath.FromStream(memoryStream), Drivers.GeoJson))
                {
                    layer.Attributes.Add(new FeatureAttribute("name", AttributeDataType.String));
                    layer.Attributes.Add(new FeatureAttribute("age", AttributeDataType.Integer));

                    Feature firstFeature = layer.ConstructFeature();
                    firstFeature.Geometry = new Point(33.97, -118.25);
                    firstFeature.SetValue("name", "John");
                    firstFeature.SetValue("age", 23);
                    layer.Add(firstFeature);

                    Feature secondFeature = layer.ConstructFeature();
                    secondFeature.Geometry = new Point(35.81, -96.28);
                    secondFeature.SetValue("name", "Mary");
                    secondFeature.SetValue("age", 54);
                    layer.Add(secondFeature);
                }
                Console.WriteLine(Encoding.UTF8.GetString(memoryStream.ToArray()));
            }
            //ExEnd: WriteGeoJsonToStream
        }
    }
}