# Aspose.GIS for .NET

[Aspose.GIS for .NET](https://products.aspose.com/gis/net) enables you to access & manipulate geographic information from vector based geospatial data formats. You can read, write & convert most popular GIS file formats such as Shapefile & GeoJSON from within your .NET applications without requiring any additional tools or software.

This repository contains [Demos](Demos), [Examples](Examples) and [Showcases](Showcases) for [Aspose.GIS for .NET](https://products.aspose.com/gis/net) to help you learn and write your own applications.

<p align="center">
<a title="Download complete Aspose.GIS for .NET source code" href="https://github.com/aspose-gis/Aspose.gis-for-.NET/archive/master.zip">
	<img src="https://raw.github.com/AsposeExamples/java-examples-dashboard/master/images/downloadZip-Button-Large.png" />
  </a>
</p>

Directory | Description
--------- | -----------
[Demos](Demos)  | Aspose.GIS for .NET Live Demos Source Code
[Examples](Examples)  | A collection of .NET examples that help you learn the product features
[Showcases](Showcases)  | Standalone ready-to-use applications that demonstrate some specific use cases

# GIS Data Manipulation & Conversion APIs for .NET

[Aspose.GIS for .NET](https://products.aspose.com/gis/net) API helps developers render maps, read, write & convert geographic information fetched from vector-based geospatial data formats without needing any other GIS software. The GIS .NET API supports working with Shapefile, GeoJSON, ESRI File Geodatabase (FileGDB), Geography Markup Language (GML), Keyhole Markup Language (KML), Scalable Vector Graphics (SVG) and many others.

It allows to read and write GIS data, [convert GIS file formats](https://docs.aspose.com/display/gisnet/Conversion), and [render maps](https://docs.aspose.com/display/gisnet/Map+Rendering) to SVG format. You can also create and analyze feature geometries as well as create basic geometries, such as, Point, MultiPoint, Line, Multiline and Polygon from scratch. The API supports to build non-linear (curve) geometries, linearize non-linear geometries, and control precision mode of calculations.

## GIS API Features

- [Render maps to PNG, JPEG, BMP, or SVG](https://docs.aspose.com/display/gisnet/Map+Rendering).
- Iterate through layer features.
- Read layer features by index.
- Fetch metadata about vector layers.
- Create new layers and datasets as well as work with multi-layer dataset.
- Convert vector data to [popular file formats](https://docs.aspose.com/display/gisnet/Supported+File+Formats).
- Perform re-projection during data conversion.
- Adjust feature attributes while converting.
- Customize styling of each geometry type.
- Perform complex drawing by combining several symbolizers.
- Apply layer rendering rules to control feature visual representation.
- Use value attributes to calculate styling parameters of a feature.
- Perform vector analysis & [manipulate geometries](https://docs.aspose.com/display/gisnet/Working+with+Geometries).
- Support for [Spatial Reference Systems](https://docs.aspose.com/display/gisnet/Spatial+Reference+Systems).

## New Features & Enhancements in Version 20.6

- Updated `EPSG` Dataset.
- Updated security.

For detailed notes, please visit [Aspose.GIS for .NET 20.6 Release Notes](https://docs.aspose.com/display/gisnet/Aspose.GIS+for+.NET+20.06+Release+Notes).

## Read & Write GIS Formats

**ESRI Shapefile:** SHP, SHX, DBF
**GeoJSON:** JSON, GeoJSON
**TopoJSON:** JSON, TopoJSON
**ESRI File Geodatabase:** GDB
**Google Earth:** KML

## Read GIS Formats

**Geography Markup Language:** GML
**GPS Exchange Format:** GPX
**MapInfo Interchange Format:** MIF
**MapInfo Tab Format:** TAB, DAT, DBF
**OpenStreetMap:** OSM
**Other:** GeoTIFF, ESRI ASCII

## Render GIS Files As Images

**Images:** SVG, PNG, JPEG, JPG, BMP

## Platform Independence

Aspose.GIS for .NET API's uniform model is based on 100% managed code. This API can be used to develop several different types of .NET apps including ASP.NET, WinForms and Windows Services. It is easy to use & deploy, and provides the ideal solution to work with geo-spatial information with .NET Framework 4.7, .NET Standard 2.0 & Xamarin platforms.

## Getting Started with Aspose.GIS for .NET

Are you ready to give Aspose.GIS for .NET a try? Simply execute `Install-Package Aspose.GIS` from Package Manager Console in Visual Studio to fetch the NuGet package. If you already have Aspose.GIS for .NET and want to upgrade the version, please execute `Update-Package Aspose.GIS` to get the latest version.

### How to Run the Examples

- You can either clone the repository using your favorite GitHub client or download the ZIP file from here.
- Extract the contents of the ZIP file to any folder on your computer. All the examples are located in the Examples folder.
- There is a Visual Studio solution file, Aspose.GIS.Examples.CSharp.sln in the folder.
- The project is created in Visual Studio 2013, but the solution file is compatible with Visual Studio 2010 SP1 and higher.
- Open the solution file in Visual Studio and build the project.
- On the first run, the dependencies will automatically be downloaded via NuGet.
- Data folder at the root folder of Examples contains input files used in code examples. It is mandatory that you download the Data folder along with the examples project.
- Open RunExamples.cs file, all the examples are called from here.
- Uncomment the examples you want to run from within the project.

Please find more details for how to run the examples [here](https://docs.aspose.com/display/gisnet/How+to+Run+the+Examples).


## Convert a Shapefile to GeoJSON Format with C#

You can execute below code snippet to see how Aspose.GIS API works after adding Aspose.GIS for .NET to your project or check the [GitHub Repository](https://github.com/aspose-gis/Aspose.GIS-for-.NET) for other common usage scenarios. 

```csharp
VectorLayer.Convert(dir + "template.shp", Drivers.Shapefile, dir + "output.json", Drivers.GeoJson);
```

[Product Page](https://products.aspose.com/gis/net) | [Docs](https://docs.aspose.com/display/gisnet/Home) | [Demos](https://products.aspose.app/gis/family) | [API Reference](https://apireference.aspose.com/gis/net) | [Examples](https://github.com/aspose-gis/Aspose.GIS-for-.NET) | [Blog](https://blog.aspose.com/category/gis/) | [Free Support](https://forum.aspose.com/c/gis) |  [Temporary License](https://purchase.aspose.com/temporary-license)
