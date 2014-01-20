using Bing.Maps.Directions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Devices.Geolocation.Geofencing;

namespace Schatzoeken.Model
{
    public class Route
    {
        private List<Waypoint> waypoints = new List<Waypoint>();
        private List<RouteObject> routeObjects = new List<RouteObject>();

        public Route()
        {
            fillTreasureRoute();
        }

        private void fillTreasureRoute()
        {
            MonitoredGeofenceStates mask = MonitoredGeofenceStates.Entered | MonitoredGeofenceStates.Exited;

            routeObjects.Add(new Hint("hint 1",new Geofence("Hint1",new Geocircle(new BasicGeoposition
                {
                    Latitude = 51.587733, 
                    Longitude = 4.782515
                },10),mask,false)));
            routeObjects.Add(new Hint("hint 2", new Geofence("Hint2", new Geocircle(new BasicGeoposition
                {
                    Latitude = 51.588315, 
                    Longitude = 4.778466
                }, 10), mask, false)));
            routeObjects.Add(new Hint("hint 3", new Geofence("Hint3", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.587141,
                Longitude = 4.775751
            }, 10), mask, false)));
            routeObjects.Add(new Hint("hint 4", new Geofence("Hint4", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.588121,
                Longitude = 4.772897
            }, 10), mask, false)));
            routeObjects.Add(new Hint("hint 5", new Geofence("Hint5", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.589341,
                Longitude = 4.774378
            }, 10), mask, false)));
            routeObjects.Add(new Hint("hint 6", new Geofence("Hint6", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.589508,
                Longitude = 4.776384
            }, 10), mask, false)));
            routeObjects.Add(new Hint("hint 7", new Geofence("Hint7", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.590348,
                Longitude = 4.776159
            }, 10), mask, false)));
            routeObjects.Add(new Hint("hint 8", new Geofence("Hint8", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.590588,
                Longitude = 4.777570
            }, 10), mask, false)));
            routeObjects.Add(new Hint("hint 9", new Geofence("Hint9", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.591834,
                Longitude = 4.777658
            }, 10), mask, false)));
            routeObjects.Add(new Hint("hint 10", new Geofence("Hint10", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.592447,
                Longitude = 4.779294
            }, 10), mask, false)));
            routeObjects.Add(new Hint("hint 11", new Geofence("Hint11", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.592194,
                Longitude = 4.778372
            }, 10), mask, false)));
            routeObjects.Add(new Hint("hint 12", new Geofence("Hint12", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.591277,
                Longitude = 4.779482
            }, 10), mask, false)));
            routeObjects.Add(new Hint("hint 13", new Geofence("Hint13", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.591201,
                Longitude = 4.780453
            }, 10), mask, false)));
            routeObjects.Add(new Hint("hint 14", new Geofence("Hint14", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.591724,
                Longitude = 4.780459
            }, 10), mask, false)));
            routeObjects.Add(new Hint("hint 15", new Geofence("Hint15", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.585977,
                Longitude = 4.791461
            }, 50), mask, false)));
        }

        public static Route GETSTANDARDROUTE()
        {
            Route route = new Route();

            MonitoredGeofenceStates mask = MonitoredGeofenceStates.Entered | MonitoredGeofenceStates.Exited;
            TimeSpan dwellTime = TimeSpan.FromSeconds(2);

            Hint hint = new Hint("Hint", new Geofence("bleh", new Geocircle(new BasicGeoposition { Latitude = 51.589495, Longitude = 4.780121 }, 10), mask, false, dwellTime));


            return route;
        }

        public void AddHint(Hint newhint)
        {
            routeObjects.Add(newhint);
        }

        public void AddMonster(Monster newMonster)
        {
            routeObjects.Add(newMonster);
        }

        public void AddTreasure(Treasure newTr)
        {
            routeObjects.Add(newTr);
        }

        public List<RouteObject> GetRouteObjects()
        {
            return routeObjects;
        }
    }
}
