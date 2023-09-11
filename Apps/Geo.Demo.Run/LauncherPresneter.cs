using System.Collections.Generic;


namespace Geo.Demo.Run
{
    internal class LauncherPresneter
    {
        public List<IDemoProject> Projects = new List<IDemoProject>();

        public LauncherPresneter()
        {
            Projects.Add(new AdvancedViewer());            
            Projects.Add(new DemoGeometryListViewer());
            Projects.Add(new MapGenerator());
            Projects.Add(new MapRendering());
            Projects.Add(new LayerConvertor());
            Projects.Add(new CoordinatesConvertor());
            Projects.Add(new CoordinatesTransformer());
            Projects.Add(new RastersViewer());
            Projects.Add(new EpsgViewer());
            Projects.Add(new FeaturesEditor());
            Projects.Add(new MLayerEditor());
            Projects.Add(new DataExtractor());
        }

        public IDemoProject GetProjectByTitle(string title)
        {
            foreach (var project in Projects)
            {
                if (project.Title == title)
                    return project;
            }
            return null;
        }

        public class AdvancedViewer : Advanced.Viewer.ProjectInfo, IDemoProject { }
        public class DemoGeometryListViewer : ProjectInfo, IDemoProject { }        
        public class MapGenerator : Map.Generator.ProjectInfo, IDemoProject { }
        public class MapRendering : Map.Rendering.ProjectInfo, IDemoProject { }
        public class LayerConvertor : Layers.Conversion.ProjectInfo, IDemoProject { }        
        public class CoordinatesConvertor : Coordinates.Convert.ProjectInfo, IDemoProject { }
        public class CoordinatesTransformer : Coordinates.Transformation.ProjectInfo, IDemoProject { }
        public class RastersViewer : Rasters.Viewer.ProjectInfo, IDemoProject { }
        public class EpsgViewer : Epsg.Viewer.ProjectInfo, IDemoProject { }
        public class FeaturesEditor : Features.Editor.ProjectInfo, IDemoProject { }
        public class MLayerEditor : Layers.InMemory.ProjectInfo, IDemoProject { }
        public class DataExtractor : Tools.Paths.ProjectInfo, IDemoProject { }
    }
}
