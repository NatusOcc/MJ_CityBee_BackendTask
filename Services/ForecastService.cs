using CityBee_task.Models;
using Newtonsoft.Json;
using System;
using System.Net;

namespace CityBee_task.Services
{
    public class ForecastService
    {
        public static ForecastModel GetForecast(DateTime date)
        {
            string json = (new WebClient()).DownloadString("https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/Vilnius/" + date.ToString("yyyy-MM-dd") + "/" + date.ToString("yyyy-MM-dd") + "?unitGroup=metric&key=HE6VS58WQKPKMAVGLGHNKJ9KC&contentType=json");

            dynamic data = JsonConvert.DeserializeObject<object>(json);

            return new ForecastModel
            {
                Date = data.days[0].datetime,
                Temperature = data.days[0].temp,
                Humidity = data.days[0].humidity,
                Wind = data.days[0].windspeed,
                Pressure = data.days[0].pressure,
            };
        }
    }
}
