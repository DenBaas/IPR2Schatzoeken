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
    public sealed partial class Popup : UserControl
    {
        public Popup()
        {
            this.InitializeComponent();
        }

        private void PopUpClosed(object sender, TappedRoutedEventArgs e)
        {
            PopupControl.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        public void setHintText(string hintInfo)
        {
            TitleBlock.Text = hintInfo;
        }
    }
}
