using System.ComponentModel.DataAnnotations;

namespace Hotel_List_API.Configuration.Models.Hotel
{
    public abstract class BaseHotelDTO
    {
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        public int CountryId { get; set; }
    }
}
