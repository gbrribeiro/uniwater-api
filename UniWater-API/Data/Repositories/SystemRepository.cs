using Microsoft.EntityFrameworkCore;
using UniWater_API.Data.Repositories.Interfaces;
using UniWater_API.Models;

namespace UniWater_API.Data.Repositories
{
    public class SystemRepository : ISystemRepository
    {
        private readonly DatabaseContext _context;
        private readonly IRecordingRepository _recordingRepository;

        public SystemRepository(DatabaseContext context, IRecordingRepository recordingRepository)
        {
            _context = context;
            _recordingRepository = recordingRepository;
        }

        public async Task<SystemParameters> AddParameters(SystemParameters parameters)
        {
            var allParameters = _context.SystemParameters.ToList();
            _context.SystemParameters.RemoveRange(allParameters);
            await _context.SystemParameters.AddAsync(parameters);
            await _context.SaveChangesAsync();
            //TODO: USER
            await _recordingRepository.AddRecord(new Recording { Operation = "Parameters Changed", OperationDate = DateTime.Now, UserFullName = "", UserId = 0});
            return parameters;
        }

        public async Task<SystemParameters> GetParameters()
        {
            var allParameters = await _context.SystemParameters.ToListAsync();
            return allParameters[0];
        }
    }
}
