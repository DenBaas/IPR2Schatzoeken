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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Schatzoeken
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Controller control = new Controller();
        private MapLayer layer = new MapLayer();
        private UserLocationIcon icon = new UserLocationIcon();
        private Geolocator geoLocation = new Geolocator();
        private Waypoint currentPoint = new Waypoint(new Bing.Maps.Location());

        public MainPage()
        {
            this.InitializeComponent();
            //Model.Route route = control.GetRoute();

            map.Children.Add(layer);
            map.Children.Add(icon);

            geoLocation.PositionChanged +=
                new TypedEventHandler<Geolocator,
                    PositionChangedEventArgs>(geoLocation_PositionChanged);
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
            control.person = new Model.Person(e.Parameter as string);
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
    }
}
