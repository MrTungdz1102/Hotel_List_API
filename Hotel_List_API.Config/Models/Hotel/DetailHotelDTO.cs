using Hotel_List_API.Models.Country;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_List_API.Models.Hotel
{
    public class DetailHotelDTO : BaseHotelDTO
    {
        public int Id { get; set; }
        
        public GetCountryDTO Country { get; set; }
    }
}
