using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Gis.Geometries;
using System.Windows.Media;

namespace Geo.Viewer.WPF
{
    internal class GeometryPresenter
    {
        public int SelectedIndex { get { return _selectedIndex; } set { _selectedIndex = value; AssignGeometry(_selectedIndex); } }
        public string SelectedWkt { get { return _selectedWkt; } }
        public string[] Titles { get { return _titles; } }

        public GeometryPresenter() { _selectedWkt = string.Empty; _selectedIndex = -1; }

        /// <summary>
        /// Forms a selected WKT string using templates of geometry objects based on the passed id
        /// </summary>
        public void AssignGeometry(int id)
        {
            switch (id)
            {
                case 0:
                    _selectedWkt = new GeometryProvider().CreatePolygon(LENGTH, WIDTH).AsText();
                    break;
                case 1:
                    _selectedWkt = new GeometryProvider().CreateCircularString(RADIUS).AsText();
                    break;
                case 2:
                    _selectedWkt = new GeometryProvider().CreatePoint(WIDTH / 2, LENGTH / 2).AsText();
                    break;
                case 3:
                    _selectedWkt = new GeometryProvider().CreatePolygonWithHole(LENGTH, WIDTH, RING).AsText();
                    break;
                case 4:
                    _selectedWkt = new GeometryProvider().CreateUnclosedPolygon(LENGTH, WIDTH).AsText();
                    break;
                case 5:
                    _selectedWkt = new GeometryProvider().CreatePolyline("0; 0, 30; 45, 30; 45, 60; 0, 60.001; 0.001, 60.001; 0, 60; 0.001, 90; 45").AsText();
                    break;
                case 6:
                    _selectedWkt = new GeometryProvider().CreatePolyline("0; 0, 30; 45, 45; 22.5, 60; 0, 75; 22.5, 75.001; 22.501, 75; 22.501, 75.001; 22, 90; 45").AsText();
                    break;
                case 7:
                    _selectedWkt = new GeometryProvider().CreateHexagon(LENGTH).AsText();
                    break;
                case 8:
                    _selectedWkt = new GeometryProvider().CreateUnclosedHexagon(LENGTH).AsText();
                    break;
                case 9:
                    _selectedWkt = new GeometryProvider().PrimitivePoint().AsText();
                    break;
                case 10:
                    _selectedWkt = new GeometryProvider().PrimitiveLinestring().AsText();
                    break;
                case 11:
                    _selectedWkt = new GeometryProvider().PrimitivePolygon().AsText();
                    break;
                case 12:
                    _selectedWkt = new GeometryProvider().PrimitivePolygonWithHole().AsText();
                    break;
                case 13:
                    _selectedWkt = new GeometryProvider().PrimitiveMultiPoint().AsText();
                    break;
                case 14:
                    _selectedWkt = new GeometryProvider().PrimitiveMultiLineString().AsText();
                    break;
                case 15:
                    _selectedWkt = new GeometryProvider().PrimitiveMultiPolygon().AsText();
                    break;
                case 16:
                    _selectedWkt = new GeometryProvider().PrimitiveMultiPolygonWithHole().AsText();
                    break;
                default:
                    _selectedWkt = id.ToString();
                    break;
            }
        }

        private const double WIDTH = 70;
        private const double LENGTH = 100;
        private const double RADIUS = 70;
        private const double RING = 0.2;

        private int _selectedIndex;
        private string _selectedWkt;
        private string[] _titles = { "Polygon", "Circle", "Point", "Polygon with Hole", "Polygon with Unclosed Ring", "Zigzag with Doubles", "Zigzag with Doubles on Midpoints", "Hexagon", "Hexagon with Missing Side",
                                    "Preset Point", "Preset Linestring", "Preset Polygon", "Preset Polygon with Hole", "Preset MultiPoint", "Preset MultiLineString", "Preset MultiPolygon", "Preset MultiPolygon With Hole"};

        /// <summary>
        /// Returns true if selected WKT string is empty, false otherwise
        /// </summary>
        private bool CheckEmptyWKT()
        {
            if (_selectedWkt == string.Empty) return true;
            return false;
        }
    }
}
