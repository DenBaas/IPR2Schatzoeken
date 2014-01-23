using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schatzoeken.Model;
using Windows.Devices.Geolocation.Geofencing;
using Windows.Devices.Geolocation;

namespace Schatzoeken.Control
{
    public class Controller
    {
        public Person Person = new Person("baas");
        public Route route;
        public bool GameEnded = false;
        //singleton
        private static Controller controller = null;

        private Controller()
        {
            route = new Route();
        }

        public static Controller GetController()
        {
            if (controller == null)
                controller = new Controller();
            return controller;
        }

        public void ResetGame()
        {
            
        }

        public void EndGame()
        {
            DataReader.GetDataReader().SavePerson(Person);
            Person = new Person();
            route = new Route();
            GameEnded = true;
        }

        public List<Geofence> getGeofences()
        {
            List<Geofence> geofences = new List<Geofence>();
            foreach(RouteObject r in route.GetRouteObjects())
            {
                geofences.Add(r.getGeofence());
            }
            return geofences;
        }

        public List<RouteObject> getRouteObjectList()
        {
            return route.GetRouteObjects();
        }
    }
}
