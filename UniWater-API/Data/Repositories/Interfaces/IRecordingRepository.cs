using UniWater_API.Models;

namespace UniWater_API.Data.Repositories.Interfaces
{
    public interface IRecordingRepository
    {
        Task<List<Recording>> GetAll();
        Task<bool> AddRecord(Recording record);
        Task DeleteOldRecords();
    }
}
