using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Geometries
{
    class ConvertGeometryToEditable
    {
        public static void Run()
        {
            //ExStart: ConvertGeometryToEditable
            ILineString readOnlyLine = (ILineString)Geometry.FromText("LINESTRING (1 1, 2 2)");

            // Interfaces inherited from IGeometry represent read-only geometries, while
            // concrete classes inherited from Geometry represent editable geometries.
            // If you need to edit a geometry represented by an interface, 'ToEditable' method should be used to
            // get an editable copy.
            LineString editableLine = readOnlyLine.ToEditable();

            // Line can be edited now
            editableLine.AddPoint(3, 3);
            Console.WriteLine(editableLine.AsText()); // LINESTRING (1 1, 2 2, 3 3)

            // Initial geometry did not change
            Console.WriteLine(readOnlyLine.AsText()); // LINESTRING (1 1, 2 2)
            //ExEnd: ConvertGeometryToEditable
        }
    }
}
