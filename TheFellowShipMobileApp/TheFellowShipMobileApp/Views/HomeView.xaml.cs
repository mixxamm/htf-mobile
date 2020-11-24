using Autofac;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using TheFellowShipMobileApp.Models;
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
            CreateGameGrid();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        public void CreateGameGrid()
        {
            string surroundingsString = App.Container.Resolve<IGameService>().GetSurroundings(GameId);
            JArray surroundings = JArray.Parse(surroundingsString);
            Console.WriteLine(surroundings.Count);
            Console.WriteLine(surroundings[0]);

            for(int i = 0; i < 6; i++)
            {
                gameTiles.RowDefinitions.Add(new RowDefinition());
                gameTiles.ColumnDefinitions.Add(new ColumnDefinition());
            }
            int counter = 0;
            foreach (dynamic surrounding in surroundings)
            {
                Location location = JsonConvert.DeserializeObject<Location>(Convert.ToString(surrounding));
                Console.WriteLine(location.Type);
                var label = new Label
                {
                    Text = location.Type.ToString(),
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                };
                gameTiles.Children.Add(label, counter++ % 6, counter / 6);
            }
            

            /*for (int rowIndex = 0; rowIndex < 3; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < 2; columnIndex++)
                {

                    var label = new Label
                    {
                        Text = $"{columnIndex} - {rowIndex}",
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center
                    };
                    gameTiles.Children.Add(label, columnIndex, rowIndex);
                }
            }*/
        }
    }
}
