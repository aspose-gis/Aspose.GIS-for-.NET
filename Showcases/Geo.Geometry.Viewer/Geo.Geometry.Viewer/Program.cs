using Geo.Geometry.Viewer;

GeometryOutput.DisplayOnMap(new GeometryProvider().CreatePolygon(70, 100), "test2");
GeometryOutput.DisplayOnMap(new GeometryProvider().CreateCircularString(40), "test1");