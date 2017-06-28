using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Services.Interfaces
{
    public interface IMazeService : IService
    {
        Task<string> GetMazeAsync(int size);
    }
}
