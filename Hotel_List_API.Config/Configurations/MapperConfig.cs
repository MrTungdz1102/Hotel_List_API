using AutoMapper;
using Hotel_List_API.Configuration.Models.Country;
using Hotel_List_API.Configuration.Models.Hotel;
using Hotel_List_API.Configuration.Models.User;
using Hotel_List_API.Data;


namespace Hotel_List_API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Country, GetCountryDTO>().ReverseMap();
            CreateMap<Country, CountryDetailDTO>().ReverseMap();
            CreateMap<Country, UpdateCountryDTO>().ReverseMap();
            
            CreateMap<Hotel, GetHotelDTO>().ReverseMap();
            CreateMap<Hotel, DetailHotelDTO>().ReverseMap();
            CreateMap<Hotel, CreateHotelDTO>().ReverseMap();
            CreateMap<Hotel, UpdateHotelDTO>().ReverseMap();

            // ApiUser, ApiUserDTO hay nguoc lai cung nhu nhau
            CreateMap<ApiUser, ApiUserDTO>().ReverseMap();
        }
    }
}
