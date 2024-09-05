namespace UniWater_API.Models
{
    public class StreamingData
    {
        public int Id { get; set; } = 0;
        public float Humidity { get; set; }
        public float Temperature { get; set; }
        public DateTime InternalClock { get; set; }
    }
}
