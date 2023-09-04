using Aspose.Gis.Geometries;
using Aspose.Gis;
using System.Text;
using System;

namespace Geo.Layers.InMemory
{
    public class ProjectPresenter
    {

        public VectorLayer _layer;

        public void CreateLayer()
        {
            //Creating a Drivers.InMemory layer.
            _layer = Drivers.InMemory.CreateLayer();

            //Creating an attribute for the feature with placeholder value.
            _layer.Attributes.Add(new FeatureAttribute("string_data", AttributeDataType.String));
        }

        public string AddAndReport(string featureValue)
        {
            var output = new StringBuilder();
            output.AppendLine($"START {nameof(AddAndReport)}").AppendLine();

            try
            {
                //Creating a new feature.
                Feature newFeature = _layer.ConstructFeature();
                newFeature.SetValue("string_data", featureValue ?? "default value");
                var defualtGeometry = new LineString(new[] { new Point(0, 0), new Point(1, 1) });
                newFeature.Geometry = defualtGeometry;

                // Add to our Layer.
                _layer.Add(newFeature);
                output.AppendLine("Success");
            }
            catch (Exception ex)
            {
                output.AppendLine($"Error:{ex.Message}");
            }

            return output.ToString();
        }

        public string ReadAddReport()
        {
            var output = new StringBuilder();
            output.AppendLine($"START {nameof(ReadAddReport)}").AppendLine();

            // print attributes
            foreach (var attribute in _layer.Attributes)
            {
                output.AppendLine($"Attribute Name: '{attribute.Name}' ");
            }

            // print records
            foreach (var feature in _layer)
            {
                var dump = feature.GetValuesDump();
                foreach (var item in dump)
                {
                    output.AppendLine($"Value: '{item}' ");
                    output.AppendLine($"Geometry: '{feature.Geometry.AsText()}: ");
                }
            }
            
            return output.ToString();
        }
    }
}
