using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace MVC.Models
{
    public class City
    {
        [Display(Name="City Name:")]
        public string Name { get; set; }
        [Display(Name ="Temperature:")]
        public float Temperature { get; set; }
        [Display(Name = "Temperature min:")]
        public float TemperatureMin { get; set; }
        [Display(Name = "Temperature max:")]
        public float TemperatureMax { get; set; }
        [Display(Name = "Humidity:")]
        public int Humidity { get; set; }
        [Display(Name = "Wind speed:")]
        public float WindSpeed { get; set; }
        [Display(Name = "Weather")]
        public string Weather { get; set; }
        [Display(Name = "Pressure")]
        public int Pressure { get; set; }
    }
}
