using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hotel_List_API.Data
{
    public class HotelListDBContext : IdentityDbContext<ApiUser>
    {
        public HotelListDBContext(DbContextOptions<HotelListDBContext> options) : base(options)
        {
            
        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new Configurations.RoleConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.CountryConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.HotelConfiguration());
            
            //modelBuilder.Entity<Country>().HasData(
            //    new Country {Id = 1, Name = "India", ShortName = "IN" },
            //    new Country {Id = 2, Name = "VietNam", ShortName = "VN" }
            //    );
        }
    }
}
