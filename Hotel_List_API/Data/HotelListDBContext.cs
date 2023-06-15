using Microsoft.EntityFrameworkCore;

namespace Hotel_List_API.Data
{
    public class HotelListDBContext : DbContext
    {
        public HotelListDBContext(DbContextOptions<HotelListDBContext> options) : base(options)
        {
            
        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                new Country {Id = 1, Name = "India", ShortName = "IN" },
                new Country {Id = 2, Name = "VietNam", ShortName = "VN" }
                );
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Id = 1, Name = "Hotel1", Address = "Address1", Rating = 5.0, CountryId = 1 },
                new Hotel { Id = 2, Name = "Hotel2", Address = "Address2", Rating = 5.0, CountryId = 2 }
                );
        }
    }
}
