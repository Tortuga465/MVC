using Microsoft.AspNetCore.Mvc;
using MVC.databaseClasses;
using MVC.Models;
using MVC.OpenWeatherMap_Model;
using MVC.Reps;


namespace MVC.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWForecastRepo _WForecastRepo;

        public WeatherController(IWForecastRepo wForecastRepo)
        {
            _WForecastRepo = wForecastRepo;
        }

        [HttpGet]
        public IActionResult CitySearch()
        {
            var viewModel = new CitySearch();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult CitySearch(CitySearch model)
        {
            if (ModelState.IsValid) 
            {
                return RedirectToAction("City", "Weather", new { city = model.CityName });

            }
            return View(model);
        }
        [HttpGet]
        public IActionResult City(string City) 
        {
            WeatherResponse weatherResponse = _WForecastRepo.GetWeather(City);
            City viewModel=new City(); 
            if(weatherResponse != null)
            {
                viewModel.Name = weatherResponse.Name;
                viewModel.Temperature = weatherResponse.Main.Temp-273;
                viewModel.Humidity = weatherResponse.Main.Humidity;
                viewModel.Pressure = weatherResponse.Main.Pressure;
                viewModel.Weather = weatherResponse.Weather[0].Main;
                viewModel.WindSpeed = weatherResponse.Wind.Speed;
                viewModel.TemperatureMin = weatherResponse.Main.Temp_Min-273;
                viewModel.TemperatureMax = weatherResponse.Main.Temp_Max-273;
            }
            return View(viewModel); 
        }
    }
}
