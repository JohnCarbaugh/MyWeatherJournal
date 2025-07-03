using System.ComponentModel.DataAnnotations;

namespace MyWeatherJournal.API.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        public ICollection<CustomerFavoriteCity> FavoriteCities { get; set; } = new List<CustomerFavoriteCity>();
    }
}
