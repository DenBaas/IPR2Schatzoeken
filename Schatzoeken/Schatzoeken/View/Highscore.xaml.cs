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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Schatzoeken.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Highscore : Page
    {

        public Highscore()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<String> niks = new List<string>();
            niks.Add("De highscore is leeg.");
            List<Model.Person> persons = Control.DataReader.GetDataReader().GetPersonsFromHighscore();
            if (persons.Count > 0)
                playersInHighscore.ItemsSource = persons;
            else
                playersInHighscore.ItemsSource = niks;
        }

        private void goBack(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPage1));
        }
    }
}
