using System.Web.Http;

using BotRace.Game;
using BotRace.Game.Implementation;

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
