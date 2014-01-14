﻿using System;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Schatzoeken
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Controller control;

        public MainPage()
        {
            this.InitializeComponent();
            Model.Route route = control.GetRoute();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            control.person = new Model.Person(e.Parameter as string);
        }
    }
}
