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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Schatzoeken.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PopupPage : UserControl
    {
        public PopupPage()
        {
            this.InitializeComponent();
        }

        private void PopUpClosed(object sender, TappedRoutedEventArgs e)
        {
            PopupControl.Visibility = Visibility.Collapsed;
        }

        public async void setHintText(string hintInfo)
        {
            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                TitleBlock.Text = hintInfo;
            });
        }

        public async void setInformationText(String information)
        {
            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                InformationBlock.Text = information;
            });
        }

        public void setImage(BitmapImage img)
        {
            ImageBlock.Source = img;
        }
    }
}
