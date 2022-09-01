using System;

namespace CityBee_task.Models
{
    public class ForecastModel
    {
        public DateTime Date { get; set; }
        public float Temperature { get; set; }
        public float Wind { get; set; }
        public int Humidity { get; set; }
        public float Pressure { get; set; }
    }
}
