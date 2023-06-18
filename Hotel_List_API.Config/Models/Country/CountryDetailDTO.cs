using Hotel_List_API.Configuration.Models.Hotel;

namespace Hotel_List_API.Configuration.Models.Country
{
    public class CountryDetailDTO : BaseCountryDTO
    {
        public int Id { get; set; }
        public List<GetHotelDTO> Hotels { get; set; }
    }
}
