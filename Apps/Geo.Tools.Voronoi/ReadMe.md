
# Tools Voronoi Polygons

The given code is using the Aspose.GIS library to generate Voronoi diagrams, a partitioning of a plane into regions based on distances to points in a specific subset of the plane.

Here are the two main operations being performed in the class ProjectPresenter:

 - MapRegularPoints(int count): This method accepts an integer as input. It generates a certain number (equal to count) of points inside a 100x100 rectangle. The points are laid out in a regular fashion (uniformly distributed). Then, Voronoi graph is generated based on these points using GeometryOperations.MakeVoronoiGraph(points). Each edge-line of the Voronoi graph is returned as LineString in a List.

 - MapRandomPoints(int count): This method is quite similar to MapPoints(int count). Yet, the difference lies in the fact that the points are randomly distributed in this case rather than being uniformly distributed.

For both methods, the Voronoi graph will be a spatial arrangement where each "line" in the graph represents a boundary between regions that are closest to each of two input points.