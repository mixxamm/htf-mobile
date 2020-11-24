using System;
using System.Threading.Tasks;
using Autofac;

namespace TheFellowShipMobileApp.Services
{
    public interface IGameService
    {
        Task<string> GetVersion();
        string GetDifficulty(int difficulty);
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

        public string GetDifficulty(int difficulty)
        {
            try
            {
                return App.Container.Resolve<IFellowshipApiService>().GetDifficulty(difficulty);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
