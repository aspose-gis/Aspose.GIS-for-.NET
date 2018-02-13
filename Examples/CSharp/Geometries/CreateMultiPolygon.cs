using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Geometries
{
    class CreateMultiPolygon
    {
        public static void Run()
        {
            //ExStart: CreateMultiPolygon
            LinearRing firstRing = new LinearRing();
            firstRing.AddPoint(8.5, -2.5);
            firstRing.AddPoint(-8.5, 2.5);
            firstRing.AddPoint(8.5, -2.5);
            Polygon firstPolygon = new Polygon(firstRing);

            LinearRing secondRing = new LinearRing();
            secondRing.AddPoint(7.6, -3.6);
            secondRing.AddPoint(-9.6, 1.5);
            secondRing.AddPoint(7.6, -3.6);
            Polygon secondPolygon = new Polygon(secondRing);

            MultiPolygon multiPolygon = new MultiPolygon();
            multiPolygon.Add(firstPolygon);
            multiPolygon.Add(secondPolygon);
            //ExEnd: CreateMultiPolygon
        }
    }
}
