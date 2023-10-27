using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class CitySearch
    {
        [Required(ErrorMessage = "No city!")]
        [Display (Name = "City Name")]
        [StringLength (50)]
        public string CityName { get; set; }
    }
}
