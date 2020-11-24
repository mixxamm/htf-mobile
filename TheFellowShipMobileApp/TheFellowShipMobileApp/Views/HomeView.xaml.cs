using Autofac;
using System;
using TheFellowShipMobileApp.Services;
using Xamarin.Forms;

namespace TheFellowShipMobileApp
{
    public partial class MainPage : ContentPage
    {
        public string GameId { get; set; }
        public MainPage()
        {
            InitializeComponent();
        }

        void GetVersion(object sender, EventArgs args)
        {
            var version = App.Container.Resolve<IGameService>().GetDifficulty(2);
            Console.WriteLine(version);
            GameId = version;
            StartLayout.IsVisible = false;
            GameLayout.IsVisible = true;
            IdLabel.Text = version;
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
