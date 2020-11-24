﻿using Autofac;
using System;
using TheFellowShipMobileApp.Services;
using Xamarin.Forms;

namespace TheFellowShipMobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void GetVersion(object sender, EventArgs args)
        {
            var version = App.Container.Resolve<IGameService>().GetVersion().Result;
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
