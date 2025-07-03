using System.ComponentModel.DataAnnotations;

namespace MyWeatherJournal.API.Models
{
    public class CustomerFavoriteCity
    {

        [Required]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        [Required]
        public int CityId { get; set; }

        public City City { get; set; }
    }
}
