using System.Collections.Generic;
using System.Fabric;
using System.Threading.Tasks;

using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;

using BotRace.Services.Interfaces;

using BotRace.Game.Implementation;
using BotRace.Game;

namespace BotRace.Services.MazeService
{
    /// <summary>
    /// An instance of this class is created for each service instance by the Service Fabric runtime.
    /// </summary>
    internal sealed class MazeService : StatelessService, IMazeService
    {
        public MazeService(StatelessServiceContext context)
            : base(context)
        { }

        public Task<string> GetMazeAsync(int size)
        {
            IMazeGenerator mg = new RecursiveBacktrackingMazeGenerator();

            var maze = mg.Create(size);

            return Task.FromResult(maze.ToJson());
        }

        /// <summary>
        /// Optional override to create listeners (e.g., TCP, HTTP) for this service replica to handle client or user requests.
        /// </summary>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new[]
            {
                new ServiceInstanceListener(this.CreateServiceRemotingListener)
            };
        }
    }
}
