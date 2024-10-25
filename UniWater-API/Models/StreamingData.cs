namespace UniWater_API.Models
{
    public class StreamingData
    {
        public int Id { get; set; } = 1;
        public float Humidity { get; set; }
        public float Temperature { get; set; }
        public DateTime InternalClock { get; set; }
    }
}
