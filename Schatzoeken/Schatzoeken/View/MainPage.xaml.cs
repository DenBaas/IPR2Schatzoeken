using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Schatzoeken.Control;
using Schatzoeken.View;
using Windows.Devices.Geolocation;
using Bing.Maps.Directions;
using Bing.Maps;
using Windows.Devices.Geolocation.Geofencing;
using Schatzoeken.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Schatzoeken
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MapLayer layer = new MapLayer();
        private UserLocationIcon icon = new UserLocationIcon();
        private Geolocator geoLocation = new Geolocator();
        private Waypoint currentPoint = new Waypoint(new Bing.Maps.Location());

        public MainPage()
        {
            this.InitializeComponent();

            map.Children.Add(layer);
            map.Children.Add(icon);

            geoLocation.PositionChanged +=
                new TypedEventHandler<Geolocator,
                    PositionChangedEventArgs>(geoLocation_PositionChanged);
            GeofenceMonitor.Current.GeofenceStateChanged += OnGeofenceStateChanged;
        }

        private async void OnGeofenceStateChanged(GeofenceMonitor sender, object args)
        {
            var reports = sender.ReadReports();
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                foreach(GeofenceStateChangeReport report in reports)
                {
                    GeofenceState state = report.NewState;
                    Geofence geo = report.Geofence;

                    if(state == GeofenceState.Removed)
                    {
                    }

                    else if(state == GeofenceState.Entered)
                    {

                    }
                    else if(state == GeofenceState.Exited)
                    {

                    }
                }
            });
        }

        private void routeObjectFound(double x, double y)
        {
            try
            {
                List<RouteObject> lijst = Controller.GetController().Route.LocationsWithRouteObjects();
                RouteObject o = null;
                foreach (RouteObject r in lijst)
                {
                    if (x == r.Location.Location.Latitude && y == r.Location.Location.Longitude)
                    {
                        o = r;
                        break;
                    }
                }
                if (o != null)
                    if (o.GetType() != typeof(Monster) && o.IsVisited())
                        return;
                o.Action();                
                hints.Items.Add(o.GetInformation());
                if(Controller.GetController().GameEnded)
                {

                }
            }
            catch(Exception e)
            {
                Debug.Print(e);
            }
        }

        private async void geoLocation_PositionChanged(Geolocator sender, PositionChangedEventArgs e)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
                {
                    currentPoint.Location.Latitude = e.Position.Coordinate.Point.Position.Latitude;
                    currentPoint.Location.Longitude = e.Position.Coordinate.Point.Position.Longitude;
                });
            changeUserLocation(currentPoint);
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

        public async void changeUserLocation(Waypoint userPoint)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
            {
                MapLayer.SetPosition(icon, new Location(userPoint.Location.Latitude, userPoint.Location.Longitude));
                map.Center = new Location(
                    userPoint.Location.Latitude,
                    userPoint.Location.Longitude);
                map.ZoomLevel = 16.0f;
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            routeObjectFound(51.591724, 4.780459);
        }
    }
}
