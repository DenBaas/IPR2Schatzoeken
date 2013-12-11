using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation.Geofencing;

namespace Schatzoeken.Model
{
    public class Hint : RouteObject
    {
        public static int POINTS = 5;


        public Hint(string newHint, Geofence newGeo) : base(newHint, newGeo)
        {

        }


        public override void Action()
        {
            throw new NotImplementedException();
        }
    }
}
