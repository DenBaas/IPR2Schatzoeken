using Bing.Maps.Directions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Devices.Geolocation.Geofencing;
using Bing.Maps;

namespace Schatzoeken.Model
{
    public class Route
    {
        private List<Waypoint> waypoints = new List<Waypoint>();
        private Dictionary<Location, RouteObject> locationsWithRouteObjects = new Dictionary<Bing.Maps.Location, RouteObject>();

        public Route()
        {
            fillTreasureRoute();
        }

        private void fillTreasureRoute()
        {
            waypoints.Add(new Waypoint(new Bing.Maps.Location(51.587733, 4.782515)));
            waypoints.Add(new Waypoint(new Bing.Maps.Location(51.588315, 4.778466)));
            waypoints.Add(new Waypoint(new Bing.Maps.Location(51.587141, 4.775751)));
            waypoints.Add(new Waypoint(new Bing.Maps.Location(51.588121, 4.772897)));
            waypoints.Add(new Waypoint(new Bing.Maps.Location(51.589341, 4.774378)));
            waypoints.Add(new Waypoint(new Bing.Maps.Location(51.589508, 4.776384)));
            waypoints.Add(new Waypoint(new Bing.Maps.Location(51.590348, 4.776159)));
            waypoints.Add(new Waypoint(new Bing.Maps.Location(51.590588, 4.777570)));
            waypoints.Add(new Waypoint(new Bing.Maps.Location(51.591834, 4.777658)));
            waypoints.Add(new Waypoint(new Bing.Maps.Location(51.592447, 4.779294)));
            waypoints.Add(new Waypoint(new Bing.Maps.Location(51.592194, 4.778372)));
            waypoints.Add(new Waypoint(new Bing.Maps.Location(51.591277, 4.779482)));
            waypoints.Add(new Waypoint(new Bing.Maps.Location(51.591201, 4.780453)));
            waypoints.Add(new Waypoint(new Bing.Maps.Location(51.591724, 4.780459)));//treasure
        }

        public static Route GETSTANDARDROUTE()
        {
            Route route = new Route();

            MonitoredGeofenceStates mask = MonitoredGeofenceStates.Entered | MonitoredGeofenceStates.Exited;
            TimeSpan dwellTime = TimeSpan.FromSeconds(2);

            Hint hint = new Hint("Hint 1", new Geofence("bleh", new Geocircle(new BasicGeoposition { Latitude = 51.589495, Longitude = 4.780121 }, 10), mask, false, dwellTime), new Waypoint(new Bing.Maps.Location(0,0)));


            return route;
        }

        public Dictionary<Location, RouteObject> LocationsWithRouteObjects()
        {
            return locationsWithRouteObjects;
        }
    }
}
