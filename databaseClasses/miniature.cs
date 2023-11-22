using System.ComponentModel.DataAnnotations;
using MVC.Models;
using Microsoft.AspNetCore.Mvc;
using MVC.OpenWeatherMap_Model;

namespace MVC.databaseClasses
{
    public class miniature : Main
    {
        [Key]
        public int Id { get; set; }
        public bool databaseReady { get; set; } = false;

    }
}
