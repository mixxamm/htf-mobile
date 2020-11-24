using Refit;
using System.Threading.Tasks;

namespace TheFellowShipMobileApp.Services
{
    public interface IFellowshipApi
    {
        [Get("/version")]
        Task<string> GetVersion();

        [Get("/start/{difficulty}")]
        Task<string> GetDifficulty();
        
        [Get("/{gameId}/code")]
        Task<dynamic> GetTiles();
    }
}
