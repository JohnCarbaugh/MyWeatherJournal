using System.ComponentModel.DataAnnotations;

namespace MyWeatherJournal.API.Models
{
    public class City
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string State { get; set; } = string.Empty;
        [Required]
        public string Country { get; set; } = string.Empty;
    }
}
