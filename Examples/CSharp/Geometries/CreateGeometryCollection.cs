using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Geometries
{
    class CreateGeometryCollection
    {
        public static void Run()
        {
            //ExStart: CreateGeometryCollection
            Point point = new Point(40.7128, -74.006);

            LineString line = new LineString();
            line.AddPoint(78.65, -32.65);
            line.AddPoint(-98.65, 12.65);

            GeometryCollection geometryCollection = new GeometryCollection();
            geometryCollection.Add(point);
            geometryCollection.Add(line);
            //ExEnd: CreateGeometryCollection
        }
    }
}
