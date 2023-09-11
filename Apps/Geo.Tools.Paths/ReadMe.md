
# Paths Finder

This code creates optimal paths.

1. Creating a RoadInfo list that includes information about road segments and velocity.
2. Adding fast roads to the list.
3. Adding slow ring roads to the list.
4. Creating a WayLayerGenerator for generating road layers and adding roads to it.
5. Finding multiple paths from a starting point (startPoint) to multiple goal points (goalPoint01, goalPoint02, goalPoint03) using a specified radius.
6. Preparing a roadsLayer for displaying on a map and adding road objects.
7. Preparing a wayLayer for displaying on a map and creating geometric objects for each found path.
8. Displaying the map using the ShowMap function and saving the map to the specified path.