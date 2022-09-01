using CityBee_task.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net;

namespace CityBee_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForecastController : ControllerBase
    {
        [HttpGet]
        public ForecastModel GetTodays()
        {
            return GetForecast(DateTime.Now);
        }

        [HttpGet("{Date}")]
        public ForecastModel GetForecast(DateTime date)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string json = (new WebClient()).DownloadString("https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/Vilnius/"+ date.ToString("yyyy-MM-dd")+"/"+ date.ToString("yyyy-MM-dd")+"?unitGroup=metric&key=HE6VS58WQKPKMAVGLGHNKJ9KC&contentType=json");

            dynamic data = JsonConvert.DeserializeObject<object>(json);


            return new ForecastModel { 
            Date = data.days[0].datetime,
            Temperature = data.days[0].temp,
            Humidity = data.days[0].humidity,
            Wind = data.days[0].windspeed,
            Pressure = data.days[0].pressure,
            };
        }
    }
}
