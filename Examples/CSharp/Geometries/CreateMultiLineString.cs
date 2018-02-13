using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Geometries
{
    class CreateMultiLineString
    {
        public static void Run()
        {
            //ExStart: CreateMultiLineString
            LineString firstLine = new LineString();
            firstLine.AddPoint(7.5, -3.5);
            firstLine.AddPoint(-9.6, 12.6);

            LineString secondLine = new LineString();
            secondLine.AddPoint(8.5, -2.6);
            secondLine.AddPoint(-8.6, 1.5);

            MultiLineString multiLineString = new MultiLineString();
            multiLineString.Add(firstLine);
            multiLineString.Add(secondLine);
            //ExEnd: CreateMultiLineString
        }
    }
}
