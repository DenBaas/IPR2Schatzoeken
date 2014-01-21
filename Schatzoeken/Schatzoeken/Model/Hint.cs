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
    public class Hint : RouteObject
    {
        public static int POINTS = 5;
        public readonly string Instruction;

        public Hint(string newHint, string newTitle, Geofence newGeo) : base(newHint ,newTitle ,newGeo, true)
        {
            Instruction = newHint;
        }

        public override void Action()
        {
            visited = true;
            Controller.GetController().Person.AddScore(POINTS);
        }
    }
}
