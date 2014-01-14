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
        private List<Hint> hints = new List<Hint>();
        private List<Monster> monsters = new List<Monster>();
        private List<Treasure> treasures = new List<Treasure>();
        private List<Waypoint> treasureRoutePoints = new List<Waypoint>();

        public Route()
        {

        }

        private void fillTreasureRoute()
        {
            treasureRoutePoints.Add(new Waypoint(new Bing.Maps.Location(51.587733, 4.782515)));
            treasureRoutePoints.Add(new Waypoint(new Bing.Maps.Location(51.588315, 4.778466)));
            treasureRoutePoints.Add(new Waypoint(new Bing.Maps.Location(51.587141, 4.775751)));
            treasureRoutePoints.Add(new Waypoint(new Bing.Maps.Location(51.588121, 4.772897)));
            treasureRoutePoints.Add(new Waypoint(new Bing.Maps.Location(51.589341, 4.774378)));
            treasureRoutePoints.Add(new Waypoint(new Bing.Maps.Location(51.589508, 4.776384)));
            treasureRoutePoints.Add(new Waypoint(new Bing.Maps.Location(51.590348, 4.776159)));
            treasureRoutePoints.Add(new Waypoint(new Bing.Maps.Location(51.590588, 4.777570)));
            treasureRoutePoints.Add(new Waypoint(new Bing.Maps.Location(51.591834, 4.777658)));
            treasureRoutePoints.Add(new Waypoint(new Bing.Maps.Location(51.592447, 4.779294)));
            treasureRoutePoints.Add(new Waypoint(new Bing.Maps.Location(51.592194, 4.778372)));
            treasureRoutePoints.Add(new Waypoint(new Bing.Maps.Location(51.591277, 4.779482)));
            treasureRoutePoints.Add(new Waypoint(new Bing.Maps.Location(51.591201, 4.780453)));
            treasureRoutePoints.Add(new Waypoint(new Bing.Maps.Location(51.591724, 4.780459)));
        }

        public static Route GETSTANDARDROUTE()
        {
            Route route = new Route();

            MonitoredGeofenceStates mask = MonitoredGeofenceStates.Entered | MonitoredGeofenceStates.Exited;
            TimeSpan dwellTime = TimeSpan.FromSeconds(2);

            Hint hint = new Hint("Hint 1", new Geofence("bleh", new Geocircle(new BasicGeoposition { Latitude = 51.589495, Longitude = 4.780121 }, 10), mask, false, dwellTime));


            return route;
        }

        public void AddHint(Hint newhint)
        {
            hints.Add(newhint);
        }

        public void AddMonster(Monster newMonster)
        {
            monsters.Add(newMonster);
        }

        public void AddTreasure(Treasure newTr)
        {
            treasures.Add(newTr);
        }

        public List<Hint> GetHints()
        {
            return hints;
        }

        public List<Monster> GetMonsters()
        {
            return monsters;
        }

        public List<Treasure> GetTreasures()
        {
            return treasures;
        }
    }
}
