using Refit;
using System.Threading.Tasks;

namespace TheFellowShipMobileApp.Services
{
    public interface IFellowshipApi
    {
        [Get("/version")]
        Task<string> GetVersion();

        [Get("/{gameId}/code")]
        Task<string> GetSurroundings(string gameid);

        [Post("/start/{difficulty}")]
        Task<string> GetDifficulty(int difficulty);

        [Put("/{gameId}/move/{direction}")]
        Task<string> MovePlayer(string gameid, int direction);


        [Get("/{gameId}/state")]
        Task<string> GetGameState(string gameId);
    }
}
