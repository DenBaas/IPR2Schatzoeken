using Bing.Maps.Directions;
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

            routeObjects.Add(new Hint("Loop 100 meter rechtdoor met de weg mee." + Environment.NewLine + "Ga linksaf en loop 200 meter rechtdoor tot de T-splitsing.","Hint 1",new Geofence("Hint 1",new Geocircle(new BasicGeoposition
                {
                    Latitude = 51.587733, 
                    Longitude = 4.782515
                },10),mask,false, new TimeSpan(1))));
            routeObjects.Add(new Hint("Ga hier linksaf en loop 300 meter rechtdoor tot de volgende T-splitsing.","Hint 2", new Geofence("Hint 2", new Geocircle(new BasicGeoposition
                {
                    Latitude = 51.588315, 
                    Longitude = 4.778466
                }, 10), mask, false,new TimeSpan(1))));
            routeObjects.Add(new Hint("Ga hier linksaf en direct weer rechtsaf." + Environment.NewLine + "Loop 300 meter rechtdoor met de bocht mee.","Hint 3" , new Geofence("Hint 3", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.587141,
                Longitude = 4.775751
            }, 10), mask, false, new TimeSpan(1))));
            routeObjects.Add(new Hint("Loop 200 meter rechtdoor met de bocht mee tot een 5 delige kruising.","Hint 4", new Geofence("Hint 4", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.588121,
                Longitude = 4.772897
            }, 10), mask, false, new TimeSpan(1))));
            routeObjects.Add(new Hint("Loop ongeveer 130 meter rechtdoor tot de T-splitsing." + Environment.NewLine + "Wat je ook doet, ga niet rechtsaf!!!","Hint 5", new Geofence("Hint 5", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.589341,
                Longitude = 4.774378
            }, 10), mask, false, new TimeSpan(1))));
            routeObjects.Add(new Hint("Ga hier linksaf en loop 94 meter rechtdoor tot het plein.","Hint 6", new Geofence("Hint 6", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.589508,
                Longitude = 4.776384
            }, 10), mask, false, new TimeSpan(1))));
            routeObjects.Add(new Hint("Ga hier rechtsaf en loop het park in." + Environment.NewLine + "Ga vervolgens linksaf tot de T-splitsing." + Environment.NewLine+"Loop in geen geval rechtdoor het park in!!!","Hint 7", new Geofence("Hint 7", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.590348,
                Longitude = 4.776159
            }, 10), mask, false, new TimeSpan(1))));
            routeObjects.Add(new Hint("Neem de links weg op de splitsing en loop ongeveer 100 meter langs het water tot de volgende splitsing.","Hint 8", new Geofence("Hint 8", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.590588,
                Longitude = 4.777570
            }, 10), mask, false, new TimeSpan(1))));
            routeObjects.Add(new Hint("Loop ongeveer 100 meter rechtdoor met de bocht mee langs het water." + Environment.NewLine + "Wacht vervolgens op de splitsing op de volgende hint!","Hint 9", new Geofence("Hint 9", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.591834,
                Longitude = 4.777658
            }, 10), mask, false, new TimeSpan(1))));
            routeObjects.Add(new Hint("Ga hier rechtsaf en loop 70 meter rechtdoor tot de splitsing." + Environment.NewLine + "Wacht hier op de volgende hint.","Hint 10", new Geofence("Hint 10", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.592447,
                Longitude = 4.779294
            }, 10), mask, false, new TimeSpan(1))));
            routeObjects.Add(new Hint("Ga rechtsaf en loop iets meer dan 100 meter rechtdoor tot de kruising." + Environment.NewLine + "","Hint 11", new Geofence("Hint 11", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.592194,
                Longitude = 4.778372
            }, 10), mask, false, new TimeSpan(1))));
            routeObjects.Add(new Hint("Loop rechtdoor op de kruising." + Environment.NewLine + "Wacht na 70 meter op de laatste hint op de kruising.","Hint 12", new Geofence("Hint 12", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.591277,
                Longitude = 4.779482
            }, 10), mask, false, new TimeSpan(1))));
            routeObjects.Add(new Hint("Op deze kruising draai je 990 graden met de klok mee." + Environment.NewLine + "Vervolgens loop je de richting op waar je heen staat." + Environment.NewLine + "De schat ligt dan (200-102)/2 meter voor je uit!","Hint 13", new Geofence("Hint 13", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.591201,
                Longitude = 4.780453
            }, 10), mask, false, new TimeSpan(1))));
            routeObjects.Add(new Treasure("Woohoo je hebt de schat gevonden!!!","De schat!", new Geofence("Hint 14", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.591724,
                Longitude = 4.780459
            }, 10), mask, false, new TimeSpan(1)),5000));
            routeObjects.Add(new Monster("Een monster!!!" + Environment.NewLine + "Vlucht snel weg in de richting waar je vandaan kwam!" + Environment.NewLine + "Dit kost je waardevolle punten!", "Monster", new Geofence("Monster 1", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.587806,
                Longitude = 4.776440
            }, 10), mask, false, new TimeSpan(1)), 100));
            routeObjects.Add(new Monster("Een monster!!!" + Environment.NewLine + "Vlucht snel weg in de richting waar je vandaan kwam!" + Environment.NewLine + "Dit kost je waardevolle punten!", "Monster", new Geofence("Monster 2", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.587228,
                Longitude = 4.775676
            }, 10), mask, false, new TimeSpan(1)), 100));
            routeObjects.Add(new Monster("Een monster!!!" + Environment.NewLine + "Vlucht snel weg in de richting waar je vandaan kwam!" + Environment.NewLine + "Dit kost je waardevolle punten!", "Monster", new Geofence("Monster 3", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.587061,
                Longitude = 4.774734
            }, 10), mask, false, new TimeSpan(1)), 100));
            routeObjects.Add(new Monster("Een monster!!!" + Environment.NewLine + "Vlucht snel weg in de richting waar je vandaan kwam!" + Environment.NewLine + "Dit kost je waardevolle punten!", "Monster", new Geofence("Monster 4", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.588132,
                Longitude = 4.773367
            }, 10), mask, false, new TimeSpan(1)), 100));
            routeObjects.Add(new Monster("Een monster!!!" + Environment.NewLine + "Vlucht snel weg in de richting waar je vandaan kwam!" + Environment.NewLine + "Dit kost je waardevolle punten!", "Monster", new Geofence("Monster 5", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.589024,
                Longitude = 4.773868
            }, 10), mask, false, new TimeSpan(1)), 100));
            routeObjects.Add(new Monster("Een monster!!!" + Environment.NewLine + "Vlucht snel weg in de richting waar je vandaan kwam!" + Environment.NewLine + "Dit kost je waardevolle punten!", "Monster", new Geofence("Monster 6", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.589094,
                Longitude = 4.774633
            }, 10), mask, false, new TimeSpan(1)), 100));
            routeObjects.Add(new Monster("Een monster!!!" + Environment.NewLine + "Vlucht snel weg in de richting waar je vandaan kwam!" + Environment.NewLine + "Dit kost je waardevolle punten!", "Monster", new Geofence("Monster 7", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.589222,
                Longitude = 4.775949
            }, 10), mask, false, new TimeSpan(1)), 100));
            routeObjects.Add(new Monster("Een monster!!!" + Environment.NewLine + "Vlucht snel weg in de richting waar je vandaan kwam!" + Environment.NewLine + "Dit kost je waardevolle punten!", "Monster", new Geofence("Monster 8", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.589534,
                Longitude = 4.776864
            }, 10), mask, false, new TimeSpan(1)), 100));
            routeObjects.Add(new Monster("Een monster!!!" + Environment.NewLine + "Vlucht snel weg in de richting waar je vandaan kwam!" + Environment.NewLine + "Dit kost je waardevolle punten!", "Monster", new Geofence("Monster 9", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.590369,
                Longitude = 4.775866
            }, 10), mask, false, new TimeSpan(1)), 100));
            routeObjects.Add(new Monster("Een monster!!!" + Environment.NewLine + "Vlucht snel weg in de richting waar je vandaan kwam!" + Environment.NewLine + "Dit kost je waardevolle punten!", "Monster", new Geofence("Monster 10", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.590652,
                Longitude = 4.777883
            }, 10), mask, false, new TimeSpan(1)), 100));
            routeObjects.Add(new Monster("Een monster!!!" + Environment.NewLine + "Vlucht snel weg in de richting waar je vandaan kwam!" + Environment.NewLine + "Dit kost je waardevolle punten!", "Monster", new Geofence("Monster 11", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.591950,
                Longitude = 4.778055
            }, 10), mask, false, new TimeSpan(1)), 100));
            routeObjects.Add(new Monster("Een monster!!!" + Environment.NewLine + "Vlucht snel weg in de richting waar je vandaan kwam!" + Environment.NewLine + "Dit kost je waardevolle punten!", "Monster", new Geofence("Monster 12", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.592180,
                Longitude = 4.778074
            }, 10), mask, false, new TimeSpan(1)), 100));
            routeObjects.Add(new Monster("Een monster!!!" + Environment.NewLine + "Vlucht snel weg in de richting waar je vandaan kwam!" + Environment.NewLine + "Dit kost je waardevolle punten!", "Monster", new Geofence("Monster 13", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.592462,
                Longitude = 4.779549
            }, 10), mask, false, new TimeSpan(1)), 100));
            routeObjects.Add(new Monster("Een monster!!!" + Environment.NewLine + "Vlucht snel weg in de richting waar je vandaan kwam!" + Environment.NewLine + "Dit kost je waardevolle punten!", "Monster", new Geofence("Monster 14", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.591197,
                Longitude = 4.780753
            }, 10), mask, false, new TimeSpan(1)), 100));
            routeObjects.Add(new Monster("Een monster!!!" + Environment.NewLine + "Vlucht snel weg in de richting waar je vandaan kwam!" + Environment.NewLine + "Dit kost je waardevolle punten!", "Monster", new Geofence("Monster 15", new Geocircle(new BasicGeoposition
            {
                Latitude = 51.591000,
                Longitude = 4.780499
            }, 10), mask, false, new TimeSpan(1)), 100));
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
