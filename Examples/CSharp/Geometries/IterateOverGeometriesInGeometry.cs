using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Geometries
{
    class IterateOverGeometriesInGeometry
    {
        public static void Run()
        {
            //ExStart: IterateOverGeometriesInGeometry
            Point pointGeometry = new Point(40.7128, -74.006);
            LineString lineGeometry = new LineString();
            lineGeometry.AddPoint(78.65, -32.65);
            lineGeometry.AddPoint(-98.65, 12.65);
            GeometryCollection geometryCollection = new GeometryCollection();
            geometryCollection.Add(pointGeometry);
            geometryCollection.Add(lineGeometry);


            foreach (Geometry geometry in geometryCollection)
            {
                switch (geometry.GeometryType)
                {
                    case GeometryType.Point:
                        Point point = (Point)geometry;
                        break;
                    case GeometryType.LineString:
                        LineString line = (LineString)geometry;
                        break;
                }
            }
            //ExEnd: IterateOverGeometriesInGeometry
        }
    }
}
