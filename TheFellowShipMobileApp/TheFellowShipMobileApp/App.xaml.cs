using Autofac;
using Refit;
using TheFellowShipMobileApp.Services;
using Xamarin.Forms;

namespace TheFellowShipMobileApp
{
    public partial class App : Application
    {
        public static IContainer Container { get; set; }

        public App()
        {
            InitializeComponent();
            Container = ConfigureContainer();
        }

        public static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance(RestService.For<IFellowshipApi>("https://hackthefuture.dev.freebility.be/fellowship"));
            builder.RegisterType<GameService>().As<IGameService>().SingleInstance();
            builder.RegisterType<FellowShipApiService>().As<IFellowshipApiService>().SingleInstance();

            return builder.Build();
        }

        protected override void OnStart()
        {
            InitApp();
        }

        private void InitApp()
        {
            MainPage = new NavigationPage(new MainPage());
        }
        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
