using System.Threading.Tasks;
using Aspose.Gis;
using System.IO;
using System.Diagnostics;

namespace Aspose.GIS.Live.Demos.UI.Models
{
	///<Summary>
	/// AsposeGisConversion class to convert gis file to different format
	///</Summary>
	public class AsposeGisConversion : GISBase
	{
		private Response ProcessTask(string fileName, string folderName, string outFileExtension, bool createZip, bool checkNumberofPages, ActionDelegate action)
		{
			Aspose.GIS.Live.Demos.UI.Models.License.SetAsposeGisLicense();
			return  Process(this.GetType().Name, fileName, folderName, outFileExtension, createZip, checkNumberofPages,  (new StackTrace()).GetFrame(5).GetMethod().Name, action);

		}

		private Driver GetDriverType(string fileName)
		{
			if (fileName.EndsWith("gpx"))
			{

				return Drivers.Gpx;
			}
			else if (fileName.EndsWith("shx"))
			{
				return Drivers.Shapefile;
			}
			else if (fileName.EndsWith("json") || fileName.EndsWith("geojson"))
			{
				return Drivers.GeoJson;
			}
			else if (fileName.EndsWith("kml"))
			{
				return Drivers.Kml;
			}

			return null;
		}
		///<Summary>
		/// ConvertGisFormat method to convert gis format to different format 
		///</Summary>
		public Response ConvertGisFormat(string fileName, string folderName, string outputType)
		{
			if (outputType.StartsWith("kml") || outputType.StartsWith("json") || outputType.StartsWith("geojson") || outputType.StartsWith("shx"))
			{
				Driver sourceDriver = GetDriverType(fileName);
				Driver destinationDriver = GetDriverType(outputType);

				if (sourceDriver != null && destinationDriver != null)
				{
					return  ProcessTask(fileName, folderName, "." + outputType, false, false, delegate (string inFilePath, string outPath, string zipOutFolder)
					{
						VectorLayer.Convert(inFilePath, (FileDriver)sourceDriver, outPath, (FileDriver)destinationDriver);
					});
				}
			}

			return new Response
			{
				FileName = null,
				Status = "Output type not found",
				StatusCode = 500
			};
		}
		///<Summary>
		/// ConvertFile
		///</Summary>
		public Response ConvertFile(string fileName, string folderName, string outputType)
		{
			fileName = fileName.ToLower();
			outputType = outputType.ToLower();

			if (outputType.StartsWith("kml") || outputType.StartsWith("json") || outputType.StartsWith("geojson") || outputType.StartsWith("shx"))
			{
				return  ConvertGisFormat(fileName, folderName, outputType);
			}

			return new Response
			{
				FileName = null,
				Status = "Output type not found",
				StatusCode = 500
			};
		}

	}
}
