using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation.Geofencing;

namespace Schatzoeken.Model
{
    public class Monster : RouteObject
    {
        public readonly int HitPoints;

        public Monster(string newMonster, Geofence newGeo, int newHitPoints) : base(newMonster,newGeo)
        {
            this.HitPoints = newHitPoints;
        }



        public override void Action()
        {
            throw new NotImplementedException();
        }
    }
}
