using System;
using System.Fabric;
using System.Threading.Tasks;

using BotRace.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Services.Remoting.Client;

namespace BotRace.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MazeController : Controller
    {
        private readonly ConfigSettings configSettings;
        private readonly StatelessServiceContext serviceContext;

        public MazeController(StatelessServiceContext serviceContext, ConfigSettings settings)
        {
            this.serviceContext = serviceContext;
            this.configSettings = settings;
        }

        // GET: api/values
        [HttpGet]
        public async Task<string> GetAsync(int size)
        {
            string serviceUri = serviceContext.CodePackageActivationContext.ApplicationName + "/" + configSettings.MazeServiceName;

            IMazeService proxy = ServiceProxy.Create<IMazeService>(new Uri(serviceUri));

            string result = await proxy.GetMazeAsync(size);

            return result;
        }
    }
}