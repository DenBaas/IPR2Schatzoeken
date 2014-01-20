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
    public class Monster : RouteObject
    {
        public readonly int HitPoints;

        public Monster(string newMonster, Geofence newGeo, int newHitPoints, Waypoint waypoint) : base(newMonster,newGeo, waypoint)
        {
            if (newHitPoints > 0)
                this.HitPoints = -1 * newHitPoints;
            else
                this.HitPoints = newHitPoints;
        }



        public override void Action()
        {
            visited = true;
            Controller.GetController().Person.AddScore(HitPoints);
        }
    }
}
