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

        public Route()
        {

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
