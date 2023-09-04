using System;
using System.Collections.Generic;
using System.IO;
using ExifLib;
using Aspose.Gis.Geometries;

namespace Geo.Advanced.Viewer.Logic
{
    public class PhotoStorage
    {
        public List<PhotoModel> LoadPhotos()
        {
            List<PhotoModel> photoList = new List<PhotoModel>();

            var photoFiles = Directory.GetFiles(@"Photos");
            foreach (var file in photoFiles)
            {
                var info = new PhotoModel();

                using (ExifReader reader = new ExifReader(file))
                {
                    if (reader.GetTagValue<DateTime>(ExifTags.DateTimeDigitized, out var dateTimeDigitized))
                    {
                        info.Created = dateTimeDigitized;
                    }

                    if (reader.GetTagValue<double[]>(ExifTags.GPSLatitude, out var lat) &&
                        reader.GetTagValue<double[]>(ExifTags.GPSLongitude, out var lon))
                    {
                        var latDidgit = lat[0] + lat[1] / 60.0 + lat[2] / 3600.0;
                        var lonDidgit = lon[0] + lon[1] / 60.0 + lon[2] / 3600.0;
                        info.Coordinate = new Point(lonDidgit, latDidgit);
                    }
                }

                info.Mark = file.Contains("best") ? PhotoModel.Marked : PhotoModel.Regular;

                photoList.Add(info);
            }
            photoList.Sort((x, y) => x.Created.Value.CompareTo(y.Created.Value));
            return photoList;
        }
    }
}
