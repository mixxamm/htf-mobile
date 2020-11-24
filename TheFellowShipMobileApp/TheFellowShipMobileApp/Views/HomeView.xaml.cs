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
            CreateGameGrid();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        public void CreateGameGrid()
        {
            gameTiles.RowDefinitions.Add(new RowDefinition());
            gameTiles.RowDefinitions.Add(new RowDefinition());
            gameTiles.RowDefinitions.Add(new RowDefinition());
            gameTiles.ColumnDefinitions.Add(new ColumnDefinition());
            gameTiles.ColumnDefinitions.Add(new ColumnDefinition());

            for (int rowIndex = 0; rowIndex < 3; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < 2; columnIndex++)
                {

                    var label = new Label
                    {
                        Text = $"${columnIndex} - {rowIndex}",
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center
                    };
                    gameTiles.Children.Add(label, columnIndex, rowIndex);
                }
            }
        }
    }
}
