using MVC.OpenWeatherMap_Model;

namespace MVC.Reps
{
    public interface IWForecastRepo
    {
        WeatherResponse GetWeather(string city);
    }
}
