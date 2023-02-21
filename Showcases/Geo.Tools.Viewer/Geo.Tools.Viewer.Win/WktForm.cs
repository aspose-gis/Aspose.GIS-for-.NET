using Aspose.Gis.Geometries;

namespace Geo.Tools.Viewer.Win
{
    public partial class WktForm : Form
    {
        public WktForm()
        {
            InitializeComponent();
        }

        private void eWkt_TextChanged(object sender, EventArgs e)
        {
            var geometry = TryParseGeometry(eWkt.Text);

            if (geometry != null)
            {
                const string fileName = "geometry.jpg";
                GeometryOutput.SaveGeometryAsMap(geometry, fileName);
                pWkt.Image = Image.FromFile(fileName);
            }
        }

        private static IGeometry TryParseGeometry(string wkt)
        {
            IGeometry geometry = null;
            try
            {
                geometry = Geometry.FromText(wkt);
            }
            catch (Exception)
            {
                geometry = null;
            }

            return geometry;
        }

        private void WktForm_Load(object sender, EventArgs e)
        {
            eWkt_TextChanged(null, null);
        }
    }
}
