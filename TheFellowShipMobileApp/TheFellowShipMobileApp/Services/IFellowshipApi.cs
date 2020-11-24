using Refit;
using System.Threading.Tasks;

namespace TheFellowShipMobileApp.Services
{
    public interface IFellowshipApi
    {
        [Get("/version")]
        Task<string> GetVersion();

    }
}
