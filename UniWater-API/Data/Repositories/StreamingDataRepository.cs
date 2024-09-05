using Microsoft.EntityFrameworkCore;
using UniWater_API.Models;

namespace UniWater_API.Data.Repositories.Interfaces
{
    public class StreamingDataRepository : IStreamingDataRepository
    {
        private readonly DatabaseContext _context;

        public StreamingDataRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<StreamingData> GetStreamingDataAsync()
        {
            var all = await _context.StreamData.ToListAsync();
            return all[0];
        }

        public async Task SaveStreamingDataAsync(StreamingData streamingData)
        {
            _context.StreamData.Update(streamingData);
            await _context.SaveChangesAsync();
        }
    }
}
