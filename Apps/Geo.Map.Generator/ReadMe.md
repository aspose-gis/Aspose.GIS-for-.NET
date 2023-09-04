
# Map Generator

This code generates random geometries using the GeoGenerator class.

A new Extent instance is created with (0, 0) as the lower-left boundary and (100, 100) as the upper-right boundary, specifying the geographical coordinates for the polygons to be generated.

Then a PolygonGeneratorOptions object is created to specify the parameters for generating the polygons.

The number of polygons to be generated is determined using the CheckInput() method.

The location of the polygons is chosen at random using the GeneratorPlaces.Random parameter.

Next, the list of generated geometries is stored in the "current" variable.

Finally, the ShowMap() function is called to display the geometries as polygons on a map.