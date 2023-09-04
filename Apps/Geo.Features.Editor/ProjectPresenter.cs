using Aspose.Gis;
using Geo.Features.Editor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using Aspose.Gis.GeoTools.Extensions;

namespace Geo.Features.Editor
{
    internal class ProjectPresenter
    {
        public VectorLayer _layer;
        List<ExampleModel> _featuresList = new();
        int _order = 0;

        public void CreateLayer()
        {
            //Creating a Drivers.InMemory layer.
            _layer = Drivers.InMemory.CreateLayer();
        }
        public string AddAndReport(string featureValue)
        {
            var output = new StringBuilder();
            output.AppendLine($"START {nameof(AddAndReport)}").AppendLine();

            CreateLayer(); //re-creating layer to enable modifying features
            _featuresList.Add(new ExampleModel() { Value = !string.IsNullOrEmpty(featureValue) ? featureValue : "0", Order = _order });
            _order += 1;
            try
            {
                _layer.AddFeatures(_featuresList);
                output.AppendLine("Success");
            }
            catch (Exception ex)
            {
                output.AppendLine("Error:" + ex.Message);
            }
            return output.ToString();
        }

        public string ReadAddReport()
        {
            var output = new StringBuilder();
            output.AppendLine($"START {nameof(ReadAddReport)}").AppendLine();

            var layerСomponents = _layer.GetObjects<ExampleModel>();

            foreach (ExampleModel model in layerСomponents)
            {
                output.AppendLine(String.Format("Feature#{0} Value: {1}", model.Order, model.Value));
            }

            return output.ToString();
        }
    }
}
