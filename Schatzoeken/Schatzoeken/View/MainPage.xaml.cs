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
using Windows.UI.Popups;
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
        private Schatzoeken.View.Popup pop = new Schatzoeken.View.Popup();

        public MainPage()
        {
            this.InitializeComponent();

            map.Children.Add(layer);
            map.Children.Add(icon);

            geoLocation.PositionChanged +=
                new TypedEventHandler<Geolocator,
                    PositionChangedEventArgs>(geoLocation_PositionChanged);
            GeofenceMonitor.Current.GeofenceStateChanged += OnGeofenceStateChanged;

            List<Geofence> geos =  Control.Controller.GetController().getGeofences();
            GeofenceMonitor.Current.Geofences.Clear();

            foreach (Geofence g in geos)
            {
                Debug.Print("Het Geo id: " + g.Id);
                if (!GeofenceMonitor.Current.Geofences.Contains(g))
                {
                    GeofenceMonitor.Current.Geofences.Add(g); 
                }
            }
        }

        private async void OnGeofenceStateChanged(GeofenceMonitor sender, object args)
        {
            UICommand showHintCommand = new UICommand("toon Hint", new UICommandInvokedHandler(commandHandler));
            UICommand closeHintCommand = new UICommand("sluit Hint", new UICommandInvokedHandler(commandHandler));
            showHintCommand.Id = 1;
            closeHintCommand.Id = 2;

            var reports = sender.ReadReports();
            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
                async () =>
                {
                    foreach(GeofenceStateChangeReport report in reports)
                    {
                        GeofenceState state = report.NewState;
                        Geofence geo = report.Geofence;
                        if(state == GeofenceState.Entered)
                        {
                            var msg = new MessageDialog(geo.Id);

                            msg.Commands.Add(showHintCommand);
                            msg.Commands.Add(closeHintCommand);
                            this.message = msg.ShowAsync();
                            await this.message;
                            Debug.Print("Hij doet het wel, waarom niet in beeld dan jonguh?");
                        }
                    }
                });
        }

        private void commandHandler(IUICommand command)
        {
            var commandId = command.Id.ToString();
            switch(commandId)
            {
                case "1":
                    pop.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    pop.setHintText("Hint");
                    break;
                case "2":
                    break;
            }
        }
            
        private void routeObjectFound(Geofence geofence)
        {
            try
            {
                Debug.Print("routeObjectfounf");
                List<RouteObject> lijst = Controller.GetController().route.GetRouteObjects();
                RouteObject o = null;
                foreach (RouteObject r in lijst)
                    if (geofence == r.getGeofence())
                    {
                        o = r;
                        break;
                    }
                if (o != null)
                    if (o.GetType() != typeof(Monster) && o.IsVisited())
                        return;
                o.Action();   
                if(Controller.GetController().GameEnded)
                {
                    Controller.GetController().EndGame();
                    Controller.GetController().Person = new Person();
                    this.Frame.Navigate(typeof(View.BlankPage1));
                    return;
                }
                else
                {
                    setTextOfScore();
                    hints.DataContext += o.GetInformation();
                    //iets met de tekst in o enzo...
                }
            }
            catch(Exception e)
            {
                Debug.Print(e);
            }
        }

        private void setTextOfScore()
        {
            score.Text = "De score van " + Controller.GetController().Person.Name + " is: " + Controller.GetController().Person.GetScore();
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
            Controller.GetController().GameEnded = false;
            setTextOfScore();
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

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            routeObjectFound(Controller.GetController().route.GetRouteObjects()[0].getGeofence());
        }

        public IAsyncOperation<IUICommand> message { get; set; }
    }
}
