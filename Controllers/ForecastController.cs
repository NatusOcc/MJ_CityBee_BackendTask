using CityBee_task.Models;
using CityBee_task.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net;

namespace CityBee_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ResponseCache(CacheProfileName = "Cache20sec")]
    public class ForecastController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTodays()
        {
            return Ok(ForecastService.GetForecast(DateTime.Now));
        }

        [HttpGet("{Date}")]
        public IActionResult GetForecast(DateTime date)
        {
            return Ok(ForecastService.GetForecast(date));
        }
    }
}
