using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using BotRace.Game;
#if _FSHARP_IMPL
using BotRace.Game.Implementation.FSharp;
using Bot = BotRace.Game.Implementation.FSharp.Bot;
#else
using BotRace.Game.Implementation.CSharp;
using Bot = BotRace.Game.Implementation.CSharp.Bot
#endif

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
            configuration.MazeGenerator = new RecursiveBacktrackingMazeGenerator();
            Func<string, Bot> botBuilder = uri => new Bot(uri);

            var race = new Game(configuration, botBuilder);

            race.Go();

            return Request.CreateResponse(HttpStatusCode.OK, race);
        }
    }
}
