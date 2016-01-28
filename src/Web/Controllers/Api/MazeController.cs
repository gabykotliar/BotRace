using System.Web.Http;

using BotRace.Game;
#if _FSHARP_IMPL
using BotRace.Game.Implementation.FSharp;
#else
using BotRace.Game.Implementation.CSharp;
#endif

namespace Web.Controllers.Api
{
    public class MazeController : ApiController
    {
        public string Get(int size)
        {
            MazeGenerator mg = new RecursiveBacktrackingMazeGenerator();

            var maze = mg.Create(size);

            return maze.ToJson();
        }
    }
}
