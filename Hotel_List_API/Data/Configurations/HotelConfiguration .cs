using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel_List_API.Data.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
                new Hotel { Id = 1, Name = "Hotel1", Address = "Address1", Rating = 5.0, CountryId = 1 },
                new Hotel { Id = 2, Name = "Hotel2", Address = "Address2", Rating = 5.0, CountryId = 2 }
                );
        }
    }
}
