using System;
using System.IO;
using System.Text;
using Aspose.Gis;

namespace Aspose.GIS.Examples.CSharp.Layers
{
    public class ReadGeoJsonFromStream
    {
        public static void Run()
        {
            //ExStart: ReadGeoJsonFromStream
            const string geoJson = @"{""type"":""FeatureCollection"",""features"":[
                {""type"":""Feature"",""geometry"":{""type"":""Point"",""coordinates"":[0, 1]},""properties"":{""name"":""John""}},
                {""type"":""Feature"",""geometry"":{""type"":""Point"",""coordinates"":[2, 3]},""properties"":{""name"":""Mary""}}
            ]}";

            using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(geoJson)))
            using (var layer = VectorLayer.Open(AbstractPath.FromStream(memoryStream), Drivers.GeoJson))
            {
                Console.WriteLine(layer.Count); // 2
                Console.WriteLine(layer[1].GetValue<string>("name")); // Mary
            }
            //ExEnd: ReadGeoJsonFromStream
        }
    }
}