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
        private string information;
        private Geofence geofence;
        private bool visited = false;
        public readonly Waypoint Location;

        public RouteObject(string newInformation, Geofence newGeo, Waypoint waypoint)
        {
            Location = waypoint;
            this.information = newInformation;
            this.geofence = newGeo;
        }

        public void setVisited()
        {
            this.visited = true;
        }

        public bool isVisited()
        {
            return visited;
        }

        public abstract void Action();
       
    }
}
