using Refit;
using System.Threading.Tasks;

namespace TheFellowShipMobileApp.Services
{
    public interface IFellowshipApi
    {
        [Get("/version")]
        Task<string> GetVersion();

        [Post("/start/{difficulty}")]
        Task<string> GetDifficulty(int difficulty);

        [Put("/{gameId}/move/{direction}")]
        Task<string> MovePlayer(string gameid, int direction);

    }
}
