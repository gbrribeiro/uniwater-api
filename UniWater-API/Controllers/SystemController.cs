using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UniWater_API.Data.Repositories.Interfaces;
using UniWater_API.Models;
using UniWater_API.Worker.Interfaces;

namespace UniWater_API.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Route("api/v1/[controller]")]
    public class SystemController
    {
        private readonly ISystemRepository systemRepository;
        private readonly IRecordingRepository recordingRepository;

        public SystemController(ISystemRepository systemRepository, IRecordingRepository recordingRepository, IBatchFactory batchFactory)
        {
            this.systemRepository = systemRepository;
            this.recordingRepository = recordingRepository;
            batchFactory.StartHangfire();
        }
        [HttpGet()]
        public async Task<SystemParameters> GetSystemParameters() 
        {
            //Get from DB
            return await systemRepository.GetParameters() ?? new SystemParameters{ DangerousTemperature = 100, HumidityOffPercentage = 80, HumidityOnPercentage = 20 };
        }

        [HttpPost()]
        public async Task<IActionResult> PostSystemParameters(SystemParameters parameters)
        {
            //Put in DB
            parameters.Id = 1;
            var result = await systemRepository.AddParameters(parameters);
            if (result == null) return new BadRequestResult();
            return new OkObjectResult(result);
        }

        [HttpGet("Records")]
        public async Task<List<Recording>> GetAllRecords()
        {
            //Get from DB
            return await recordingRepository.GetAll();
        }



    }
}
