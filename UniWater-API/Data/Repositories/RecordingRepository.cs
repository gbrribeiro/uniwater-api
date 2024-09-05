using Microsoft.EntityFrameworkCore;
using UniWater_API.Data.Repositories.Interfaces;
using UniWater_API.Models;

namespace UniWater_API.Data.Repositories
{
    public class RecordingRepository : IRecordingRepository
    {
        private readonly DatabaseContext _context;

        public RecordingRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<bool> AddRecord(Recording record)
        {
            try
            {
                await _context.AddAsync(record);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task DeleteOldRecords()
        {
            var fiveOldDay = DateTime.Now.AddDays(-5);
            var records = _context.Records.Where(p => p.OperationDate <= fiveOldDay);
            if (records.Any() || records != null)
            {
                _context.Records.RemoveRange(records);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Recording>> GetAll()
        {
            return await _context.Records.ToListAsync();
        }
    }
}
