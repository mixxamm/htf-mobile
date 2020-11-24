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
            var version = App.Container.Resolve<IGameService>().GetDifficulty(Difficulty.SelectedIndex);
            GameId = version;
            StartLayout.IsVisible = false;
            GameLayout.IsVisible = true;
            IdLabel.Text = version;
            Game game = JsonConvert.DeserializeObject<Game>(App.Container.Resolve<IGameService>().GetGameState(GameId));
            CreateGameGrid(game);
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        public void CreateGameGrid(Game game)
        {
            gameTiles.Children.Clear();
            gameTiles.ColumnDefinitions.Clear();
            gameTiles.RowDefinitions.Clear();

            for (int i = 0; i < game.BoardHeight; i++)
            {
                gameTiles.RowDefinitions.Add(new RowDefinition());
                gameTiles.ColumnDefinitions.Add(new ColumnDefinition());
            }
            foreach (Location location in game.FirewallLocations)
            {
                AddLocation(location);
            }

            foreach(Location location in game.NetgullLocations)
            {
                AddLocation(location);
            }

            AddLocation(game.PlayerLocation);
            AddLocation(game.McafeeLocation);

           
            

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

        private void MoveButton_Clicked(object sender, EventArgs e)
        {
            int id;
            switch ((sender as Button).Text)
            {
                case "Up":
                    id = 3;
                    break;
                case "Down":
                    id = 1;
                    break;
                case "Left":
                    id = 4;
                    break;
                case "Right":
                    id = 2;
                    break;
                default:
                    id = 0;
                    break;
            }
            
            
            string result = App.Container.Resolve<IGameService>().MovePlayer(GameId, id);
            if(result != null)
            {
                Game game = JsonConvert.DeserializeObject<Game>(result);
                if (game.GameState == GameStates.InProgress)
                    CreateGameGrid(game);
                else if (game.GameState == GameStates.Won)
                {
                    GameLayout.IsVisible = false;
                    EndLayout.IsVisible = true;
                    ResultLabel.Text = "You win!";
                    ResultLabel.TextColor = Color.Green;
                }
                else
                {
                    GameLayout.IsVisible = false;
                    EndLayout.IsVisible = true;
                    ResultLabel.Text = "You loose ☹!";
                    ResultLabel.TextColor = Color.Red;
                }
            }
            
        }

        private void AddLocation(Location location)
        {
            if (location != null)
            {
                var label = new Image
                {
                    Source = $"{location.Type.ToString().Substring(0, 1).ToLower()}.png",
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                };
                if (location != null)
                    gameTiles.Children.Add(label, location.x, location.y);
            }
        }

        private void RestartButton_Clicked(object sender, EventArgs e)
        {
            GameLayout.IsVisible = false;
            EndLayout.IsVisible = false;
            StartLayout.IsVisible = true;
        }

        private void PowerUpButton_Clicked(object sender, EventArgs e)
        {
            string surroundingsString = App.Container.Resolve<IGameService>().GetSurroundings(GameId);
            JArray surroundings = JArray.Parse(surroundingsString);
            foreach(dynamic surroundingString in surroundings)
            {
                Location location = JsonConvert.DeserializeObject<Location>(Convert.ToString(surroundingString));
                AddLocation(location);
            }
        }
    }
}
