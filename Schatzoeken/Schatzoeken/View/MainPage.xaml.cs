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
using Windows.UI;
using Windows.UI.Xaml.Media.Imaging;

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
        private List<RouteObject> routeObjectList = Control.Controller.GetController().getRouteObjectList();
        //PopupPage pop = new PopupPage();

        public MainPage()
        {
            this.InitializeComponent();

            map.Children.Add(layer);
            map.Children.Add(icon);

            geoLocation.PositionChanged += new TypedEventHandler<Geolocator,
                    PositionChangedEventArgs>(geoLocation_PositionChanged);
            GeofenceMonitor.Current.GeofenceStateChanged += OnGeofenceStateChanged;
        }

        private void startGame()
        {
            List<Geofence> geos = Control.Controller.GetController().getGeofences();
            GeofenceMonitor.Current.Geofences.Clear();s

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
                            var msg = new MessageDialog("");
                            routeObjectFound(geo);
                            foreach (RouteObject r in routeObjectList)
                            {   
                                if(r.getGeofence() == geo)
                                    msg = new MessageDialog(r.getTitle());
                                Debug.Print(r.GetInformation());
                            }
                            //msg.Commands.Add(showHintCommand);
                            //msg.Commands.Add(closeHintCommand);
                            this.message = msg.ShowAsync();
                            await this.message;
                        }
                        if(state == GeofenceState.Exited)
                        {

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
                    this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, ()=>
                    {
                        //pop.Visibility = Visibility.Visible;
                    }).AsTask().Wait();
                    break;
                case "2":
                    break;
            }
        }
            
        private async void routeObjectFound(Geofence geo)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    try
                    {
                        foreach (RouteObject r in routeObjectList)
                        {
                            if (r.getGeofence() == geo)
                            {
                                r.Action();
                                PopupPage pop = new PopupPage();
                                pop.setInformationText(r.GetInformation());
                                pop.setHintText(r.getTitle());
                                layer.Children.Add(pop);
                                MapLayer.SetPosition(pop, new Location(currentPoint.Location.Latitude, currentPoint.Location.Longitude));
                                if (r.getIsHint())
                                {
                                    hints.Items.Add(r.getTitle());
                                    pop.setImage(new BitmapImage(new Uri("ms-appx:///Assets/hint.png", UriKind.Absolute)));
                                }
                                if (r.getIsMonster())
                                    pop.setImage(new BitmapImage(new Uri("ms-appx:///Assets/cuteMonster.png", UriKind.Absolute)));
                                if (r.getIsTreasure())
                                    pop.setImage(new BitmapImage(new Uri("ms-appx:///Assets/chest.png", UriKind.Absolute)));
                                if (Controller.GetController().GameEnded)
                                {
                                    Controller.GetController().EndGame(true);
                                }
                                return;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.Print(e);
                    }
                });
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
            startGame();
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

        private async void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SolidColorBrush color = new SolidColorBrush();
            color.Color = Colors.Transparent;
            hints.Background = color;
            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, 
                ()=>
                {
                    foreach (RouteObject r in routeObjectList)
                    {
                        if (r.getTitle() == hints.SelectedItem.ToString())
                        {
                            PopupPage pop2 = new PopupPage();
                            pop2.Visibility = Visibility.Visible;
                            pop2.setInformationText(r.GetInformation());
                            pop2.setHintText("Hint");
                            pop2.setImage(new BitmapImage(new Uri("ms-appx:///Assets/hint.png", UriKind.Absolute)));

                            layer.Children.Add(pop2);

                            MapLayer.SetPosition(pop2, new Location(currentPoint.Location.Latitude, currentPoint.Location.Longitude));
                        }
                    }
                });
        }

        public IAsyncOperation<IUICommand> message { get; set; }

        private void hints_Tapped(object sender, TappedRoutedEventArgs e)
        {
            SolidColorBrush color = new SolidColorBrush();
            color.Color = Colors.Transparent;
            hints.Background = color;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Controller.GetController().EndGame(true);
            this.Frame.Navigate(typeof(View.BlankPage1));
        }
    }
}
