using Aspose.Gis;
using Aspose.Gis.Geometries;
using Aspose.GIS.Examples.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS_for.NET.Layers
{
    class CreateFileGdbDataset
    {
        public static void Run()
        {
            //ExStart: CreateFileGdbDataset
            Console.WriteLine(Drivers.FileGdb.CanCreateDatasets); // True
            var path = RunExamples.GetDataDir() + "Working\\CreateFileGdbDataset.gdb";

            using (var dataset = Dataset.Create(path, Drivers.FileGdb))
            {
                Console.WriteLine(dataset.LayersCount); // 0

                using (var layer = dataset.CreateLayer("layer_1"))
                {
                    layer.Attributes.Add(new FeatureAttribute("value", AttributeDataType.Integer));

                    for (int i = 0; i < 10; ++i)
                    {
                        var feature = layer.ConstructFeature();
                        feature.SetValue("value", i);
                        feature.Geometry = new Point(i, i);
                        layer.Add(feature);
                    }
                }

                using (var layer = dataset.CreateLayer("layer_2"))
                {
                    var feature = layer.ConstructFeature();
                    feature.Geometry = new LineString(new[]
                    {
                        new Point(1, 2),
                        new Point(3, 4),
                    });
                    layer.Add(feature);
                }

                Console.WriteLine(dataset.LayersCount); // 2
            }
            //ExEnd: CreateFileGdbDataset
        }
    }
}
