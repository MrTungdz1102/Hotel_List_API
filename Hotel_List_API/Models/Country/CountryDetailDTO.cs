using Hotel_List_API.Models.Hotel;

namespace Hotel_List_API.Models.Country
{
    public class CountryDetailDTO : BaseCountryDTO
    {
        public int Id { get; set; }
        public List<GetHotelDTO> Hotels { get; set; }
    }
}
