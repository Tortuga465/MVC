using MVC.OpenWeatherMap_Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using MVC.OpenWeatherMap_Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace MVC.Reps
{
    public class WForecastRepo : IWForecastRepo
    {
        public WeatherResponse GetWeather(string city)
        {
            string APP_ID = Config.Values.OPEN_WEATHER_APP_KEY;
            var options = new RestClientOptions($"https://api.openweathermap.org/data/2.5/weather?q={city}&APPID={APP_ID}");
            var client = new RestClient(options);

            //var client = new RestClient($"https://api.openweathermap.org/data/2.5/weather?q={city}&APPID={APP_ID}");

            var request = new RestRequest($"https://api.openweathermap.org/data/2.5/weather?q={city}&APPID={APP_ID}");
            RestResponse response = client.Execute(request);
            if(response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);
                return content?.ToObject<WeatherResponse>();
            }
            else
            {
                return null;
            }
        }
    }
}
