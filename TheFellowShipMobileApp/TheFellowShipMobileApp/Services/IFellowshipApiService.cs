using System;
using System.Threading.Tasks;

namespace TheFellowShipMobileApp.Services
{
    public interface IFellowshipApiService
    {
        Task<string> GetVersion();
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
                return _fellowshipApi.GetVersion().Result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
