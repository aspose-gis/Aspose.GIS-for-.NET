using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspose.GIS.Live.Demos.UI.Models
{
	///<Summary>
	/// License class to set apose products license
	///</Summary>
	public static class License
	{
		private static string _licenseFileName = "Aspose.Total.lic";

		///<Summary>
		/// SetAsposeGisLicense method to Aspose.ThreeD License
		///</Summary>
		public static void SetAsposeGisLicense()
		{
			try
			{

				Aspose.Gis.License lic = new Aspose.Gis.License();
				lic.SetLicense(_licenseFileName);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}	
		
	}
}
