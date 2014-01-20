using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation.Geofencing;
using Bing.Maps.Directions;

namespace Schatzoeken.Model
{
    public abstract class RouteObject
    {
        protected string information;
        protected Geofence geofence;
        protected bool visited = false;
        public readonly Waypoint Location;

        public RouteObject(Waypoint w)
        {
            Location = w;
        }

        public RouteObject(string newInformation, Geofence newGeo, Waypoint waypoint)
        {
            Location = waypoint;
            this.information = newInformation;
            this.geofence = newGeo;
        }

        public void SetVisited()
        {
            this.visited = true;
        }

        public bool IsVisited()
        {
            return visited;
        }

        public string GetInformation()
        {
            return information;
        }

        public abstract void Action();
       
    }
}
