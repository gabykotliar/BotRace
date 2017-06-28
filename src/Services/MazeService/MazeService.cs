using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;
using Services.Interfaces;
using BotRace.Game.Implementation;
using BotRace.Game;

namespace MazeService
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
            MazeGenerator mg = new RecursiveBacktrackingMazeGenerator();

            var maze = mg.Create(size);

            return Task.FromResult(maze.ToJson());

          //return Task.FromResult(string.Empty);
        }

        /// <summary>
        /// Optional override to create listeners (e.g., TCP, HTTP) for this service replica to handle client or user requests.
        /// </summary>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new ServiceInstanceListener[1]
            {
                new ServiceInstanceListener(this.CreateServiceRemotingListener)
            };
        }
    }
}
