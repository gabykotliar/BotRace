using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using BotRace.Game;

namespace Web.Controllers.Api
{
    public class GameController : ApiController
    {
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Default
        [HttpPost]        
        public HttpResponseMessage Post([FromBody]GameConfig configuration)
        {
            configuration.MazeGenerator = new BotRace.Game.Implementation.RecursiveBacktrackingMazeGenerator();
            Func<string, Bot> botBuilder = uri => new BotRace.Game.Implementation.Bot(uri);

            var race = new Game(configuration, botBuilder);

            race.Go();

            return Request.CreateResponse(HttpStatusCode.OK, race);
        }
    }
}
