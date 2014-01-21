﻿using Bing.Maps.Directions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Devices.Geolocation.Geofencing;
using Bing.Maps;

namespace Schatzoeken.Model
{
    public class Route
    {
        private List<RouteObject> routeObjects = new List<RouteObject>();

        public Route()
        {
            fillTreasureRoute();
        }

        private void fillTreasureRoute()
        {
            MonitoredGeofenceStates mask = MonitoredGeofenceStates.Entered | MonitoredGeofenceStates.Exited;

            routeObjects.Add(new Hint("","Hint 1",new Geofence("Hint 1",new Geocircle(new BasicGeoposition
                {
                    Latitude = 51.587733, 
                    Longitude = 4.782515
                },10),mask,false, new TimeSpan(1))));
            routeObjects.Add(new Hint("Bij deze plaats moet je 100 meter naar rechts en dan 500 meter rechtdoor!","Hint 2", new Geofence("Hint 2", new Geocircle(new BasicGeoposition
                {
                    Latitude = 51.588315, 
                    Longitude = 4.778466
                }, 10), mask, false,new TimeSpan(1))));
            routeObjects.Add(new Hint("","Hint 3" , new Geofence("Hint 3", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.587141,
                Longitude = 4.775751
            }, 10), mask, false, new TimeSpan(1))));
            routeObjects.Add(new Hint("","Hint 4", new Geofence("Hint 4", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.588121,
                Longitude = 4.772897
            }, 10), mask, false, new TimeSpan(1))));
            routeObjects.Add(new Hint("","Hint 5", new Geofence("Hint 5", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.589341,
                Longitude = 4.774378
            }, 10), mask, false, new TimeSpan(1))));
            routeObjects.Add(new Hint("","Hint 6", new Geofence("Hint 6", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.589508,
                Longitude = 4.776384
            }, 10), mask, false, new TimeSpan(1))));
            routeObjects.Add(new Hint("","Hint 7", new Geofence("Hint 7", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.590348,
                Longitude = 4.776159
            }, 10), mask, false, new TimeSpan(1))));
            routeObjects.Add(new Hint("","Hint 8", new Geofence("Hint 8", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.590588,
                Longitude = 4.777570
            }, 10), mask, false, new TimeSpan(1))));
            routeObjects.Add(new Hint("","Hint 9", new Geofence("Hint 9", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.591834,
                Longitude = 4.777658
            }, 10), mask, false, new TimeSpan(1))));
            routeObjects.Add(new Hint("","Hint 10", new Geofence("Hint 10", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.592447,
                Longitude = 4.779294
            }, 10), mask, false, new TimeSpan(1))));
            routeObjects.Add(new Hint("","Hint 11", new Geofence("Hint 11", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.592194,
                Longitude = 4.778372
            }, 10), mask, false, new TimeSpan(1))));
            routeObjects.Add(new Hint("","Hint 12", new Geofence("Hint 12", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.591277,
                Longitude = 4.779482
            }, 10), mask, false, new TimeSpan(1))));
            routeObjects.Add(new Hint("","Hint 13", new Geofence("Hint 13", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.591201,
                Longitude = 4.780453
            }, 10), mask, false, new TimeSpan(1))));
            routeObjects.Add(new Hint("Woohoo je hebt de schat gevonden!!!","De schat!", new Geofence("Hint 14", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.591724,
                Longitude = 4.780459
            }, 10), mask, false, new TimeSpan(1))));
        }

        public static Route GETSTANDARDROUTE()
        {
            Route route = new Route();

            TimeSpan dwellTime = TimeSpan.FromSeconds(2);

            //Hint hint = new Hint("Hint", new Geofence("bleh", new Geocircle(new BasicGeoposition { Latitude = 51.589495, Longitude = 4.780121 }, 10), mask, false, dwellTime));


            return route;
        }

        public List<RouteObject> GetRouteObjects()
        {
            return routeObjects;
        }
    }
}
