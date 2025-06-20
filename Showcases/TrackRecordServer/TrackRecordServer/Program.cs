using Aspose.Gis.Geometries;
using Aspose.Gis.SpatialReferencing;
using Aspose.Gis;
using TrackRecordServer.SignalR;

namespace TrackRecordServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();
            builder.Services.AddSignalR();

            builder.Services.AddSingleton((sp) => 
            {
                string filePath = "e:\\Aspose\\TrackerFiles\\route.gpx";

                using (var layer = Drivers.Gpx.OpenLayer(filePath))
                {
                    var routeLine = (LineString)((MultiLineString)layer[12].Geometry).First();

                    var tr = SpatialReferenceSystem.Wgs84.CreateTransformationTo(SpatialReferenceSystem.CreateFromEpsg(32635));

                    routeLine = (LineString)tr.Transform(routeLine);

                    Console.WriteLine($"Route length: {routeLine.GetLength()}");

                    return new Model.Route(routeLine);
                }
                ;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapHub<CoordinatesHub>("/coordinatesHub");
            app.MapControllers();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
