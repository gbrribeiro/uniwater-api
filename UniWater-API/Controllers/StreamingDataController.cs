using Microsoft.AspNetCore.Mvc;
using UniWater_API.Data.Repositories;
using UniWater_API.Data.Repositories.Interfaces;
using UniWater_API.Models;
using UniWater_API.Worker.Interfaces;

namespace UniWater_API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StreamingDataController
    {
        private readonly IStreamingDataRepository _dataRepository;

        public StreamingDataController(IStreamingDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public async Task<StreamingData> GetStreamingData()
        {
            //Used by mobile
            return await _dataRepository.GetStreamingDataAsync();
        }

        [HttpPost]
        public async Task PostStreamingData(StreamingData streamingData)
        {
            //Used by arduino
            streamingData.Id = 0;
            await _dataRepository.SaveStreamingDataAsync(streamingData);
        }
    }
}