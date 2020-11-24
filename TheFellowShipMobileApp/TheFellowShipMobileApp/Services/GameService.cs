using System;
using System.Threading.Tasks;
using Autofac;

namespace TheFellowShipMobileApp.Services
{
    public interface IGameService
    {
        Task<string> GetVersion();
    }

    public class GameService : IGameService
    {
        public GameService()
        {
        }

        public async Task<string> GetVersion()
        {
            try
            {
                return await App.Container.Resolve<IFellowshipApiService>().GetVersion();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
