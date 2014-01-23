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
    public sealed partial class Help : Page
    {
        public Help()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            text.Text = "1. Vul je naam in." + Environment.NewLine + Environment.NewLine
                + "2. Klik op 'Start' om te beginnen." + Environment.NewLine + Environment.NewLine
                + "3. Zorg dat je voor het Chassé Theater staat om de eerste hint te krijgen in je zoektocht naar de schat." + Environment.NewLine + Environment.NewLine
                + "4. Zodra je een hint krijgt verschijnt informatie om naar de volgende hint te gaan en uiteindelijk naar de schat te komen." + Environment.NewLine + Environment.NewLine
                + "5. Onderweg bestaat de mogelijkheid dat je monsters tegen komt, probeer deze te vermijden." + Environment.NewLine + Environment.NewLine
                + "6. Zodra je de schat hebt gevonden ga je terug naar het hoofdscherm door op de knop 'Argh stop this scurvy hunt' te klikken" + Environment.NewLine + Environment.NewLine
                + "7. Klik op de knop 'Highscore' om te zien wat je score is en op welke plaats je staat." + Environment.NewLine + Environment.NewLine 
                + "8. Veel succes met de jacht naar de schat!";
        }

        private void goBack(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPage1));
        }
    }
}
