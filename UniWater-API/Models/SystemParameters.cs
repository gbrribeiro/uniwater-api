namespace UniWater_API.Models
{
    public class SystemParameters
    {
        public int Id { get; set; } = 0;
        public int HumidityOffPercentage { get; set; }
        public int HumidityOnPercentage { get; set; }
        public float DangerousTemperature { get; set; }
        //public DateTime TurnOnTime { get; set; }
        //public DateTime TurnOffTime { get; set; }

    }
}
