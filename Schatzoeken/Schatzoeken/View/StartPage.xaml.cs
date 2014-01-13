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
    public sealed partial class BlankPage1 : Page
    {
        public BlankPage1()
        {
            this.InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(NameBox.Text != "" && NameBox.Text.Length > 2 && NameBox.Text.Length <30 )
                Start.Visibility = Windows.UI.Xaml.Visibility.Visible;
            else
                Start.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Button_Click(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), NameBox.Text);
        }

        private void goToHighscore(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Highscore));
        }
    }
}
