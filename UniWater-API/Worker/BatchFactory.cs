using Hangfire;
using UniWater_API.Data.Repositories.Interfaces;
using UniWater_API.Worker.Interfaces;

namespace UniWater_API.Worker
{
    public class BatchFactory : IBatchFactory
    {
        private readonly IRecordingRepository recordingRepository;

        public BatchFactory(IRecordingRepository recordingRepository)
        {
            this.recordingRepository = recordingRepository;
        }

        public void StartHangfire()
        {
            RecurringJob.AddOrUpdate("DeleteOldRecords", () => recordingRepository.DeleteOldRecords(), Cron.Daily);
        }
    }
}
