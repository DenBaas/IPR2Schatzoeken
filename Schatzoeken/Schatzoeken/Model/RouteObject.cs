using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation.Geofencing;
using Bing.Maps.Directions;
using Bing.Maps;

namespace Schatzoeken.Model
{
    public abstract class RouteObject
    {
        protected string information,title;
        protected Geofence geofence;
        protected bool visited = false;
        protected bool isHint = false;

        public RouteObject(string newInformation, string newTitle, Geofence newGeo, bool isNotMonster)
        {
            this.information = newInformation;
            this.title = newTitle;
            this.geofence = newGeo;
            this.isHint = isNotMonster;
        }

        public void SetVisited()
        {
            this.visited = true;
        }

        public bool IsVisited()
        {
            return visited;
        }

        public Geofence getGeofence()
        {
            return this.geofence;
        }

        public string GetInformation()
        {
            return information;
        }

        public string getTitle()
        {
            return title;
        }

        public bool getIsHint()
        {
            return isHint;
        }

        public abstract void Action();


        internal bool getIsMonster()
        {
            bool isMonster = false;
            if (this.GetType().Equals(new Monster().GetType()))
            {
                isMonster = true;
            }
            return isMonster;
        }
    }
}
