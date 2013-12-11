using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation.Geofencing;

namespace Schatzoeken.Model
{
    public abstract class RouteObject
    {
        private string information;
        private Geofence geofence;
        private bool visited = false;

        public RouteObject(string newInformation, Geofence newGeo)
        {
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
