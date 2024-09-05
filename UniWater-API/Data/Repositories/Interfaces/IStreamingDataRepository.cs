using UniWater_API.Models;

namespace UniWater_API.Data.Repositories.Interfaces
{
    public interface IStreamingDataRepository
    {
        Task<StreamingData> GetStreamingDataAsync();
        Task SaveStreamingDataAsync(StreamingData streamingData);
    }
}
