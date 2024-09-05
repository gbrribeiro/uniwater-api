using UniWater_API.Models;

namespace UniWater_API.Data.Repositories.Interfaces
{
    public interface ISystemRepository
    {
        Task<SystemParameters> AddParameters(SystemParameters parameters);
        Task<SystemParameters> GetParameters();
    }
}
