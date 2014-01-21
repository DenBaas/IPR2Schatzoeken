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

        public Treasure(string newTreasure,string newTitle, Geofence newGeo, int newPoints) : base(newTreasure,newTitle ,newGeo)
        {
            this.Points = newPoints;
        }

        public override void Action()
        {
            visited = true;
            Controller.GetController().GameEnded = true;
            Controller.GetController().Person.AddScore(Points);
        }
    }
}
