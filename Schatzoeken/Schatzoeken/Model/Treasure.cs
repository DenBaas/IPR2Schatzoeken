using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation.Geofencing;
using Bing.Maps.Directions;
using Schatzoeken.Control;

namespace Schatzoeken.Model
{
    public class Treasure : RouteObject
    {
        public readonly int Points;

        public Treasure(string newTreasure, int newPoints, Waypoint waypoint) : base(waypoint)
        {
            this.Points = newPoints;
        }

        public Treasure(string newTreasure, Geofence newGeo, int newPoints, Waypoint waypoint) : base(newTreasure, newGeo, waypoint)
        {
            this.Points = newPoints;
        }

        public override void Action()
        {
            visited = true;
            Controller.GetController().Person.AddScore(Points);
            Controller.GetController().EndGame();
        }
    }
}
