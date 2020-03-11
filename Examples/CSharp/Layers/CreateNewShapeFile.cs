using Aspose.Gis;
using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Layers
{
    class CreateNewShapeFile
    {
        public static void Run()
        {
            string dataDir = RunExamples.GetDataDir();

            //ExStart: CreateNewShapeFile
            using (VectorLayer layer = VectorLayer.Create(dataDir + "NewShapeFile_out.shp", Drivers.Shapefile))
            {
                // add attributes before adding features
                layer.Attributes.Add(new FeatureAttribute("name", AttributeDataType.String));
                layer.Attributes.Add(new FeatureAttribute("age", AttributeDataType.Integer));
                layer.Attributes.Add(new FeatureAttribute("dob", AttributeDataType.DateTime));

                // case 1: sets values
                Feature firstFeature = layer.ConstructFeature();
                firstFeature.Geometry = new Point(33.97, -118.25);
                firstFeature.SetValue("name", "John");
                firstFeature.SetValue("age", 23);
                firstFeature.SetValue("dob", new DateTime(1982, 2,5, 16, 30,0));
                layer.Add(firstFeature);
                
                Feature secondFeature = layer.ConstructFeature();
                secondFeature.Geometry = new Point(35.81, -96.28);
                secondFeature.SetValue("name", "Mary");
                secondFeature.SetValue("age", 54);
                secondFeature.SetValue("dob", new DateTime(1984, 12, 15, 15, 30, 0));
                layer.Add(secondFeature);

                // case 2: sets new values for all of the attributes.
                Feature thirdFeature = layer.ConstructFeature();
                secondFeature.Geometry = new Point(34.81, -92.28);
                object[] data = new object[3] {"Alex", 25, new DateTime(1989, 4, 15, 15, 30, 0)};
                secondFeature.SetValues(data);
                layer.Add(thirdFeature);
            }
            //ExEnd: CreateNewShapeFile
        }
    }
}
