using System;
using System.Threading.Tasks;

namespace TheFellowShipMobileApp.Services
{
    public interface IFellowshipApiService
    {
        Task<string> GetVersion();
        string GetDifficulty(int difficulty);
        string MovePlayer(string gameid, int direction);
    }
    public class FellowShipApiService : IFellowshipApiService
    {
        private readonly IFellowshipApi _fellowshipApi;

        public FellowShipApiService(IFellowshipApi fellowshipApi)
        {
            _fellowshipApi = fellowshipApi;
        }

        

        public async Task<string> GetVersion()
        {
            try
            {
                return  _fellowshipApi.GetVersion().Result;
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
                var result = _fellowshipApi.GetDifficulty(difficulty).Result;

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string MovePlayer(string gameid, int direction)
        {
            try
            {
                var result = _fellowshipApi.MovePlayer(gameid, direction).Result;

                Console.WriteLine("Result: " + result);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
