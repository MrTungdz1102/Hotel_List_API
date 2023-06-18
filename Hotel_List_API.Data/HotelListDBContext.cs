using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
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


        // fix loi khi add controller sau khi refactor architecture project
        public class HotelListingDbContextFactory : IDesignTimeDbContextFactory<HotelListDBContext>
        {
            public HotelListDBContext CreateDbContext(string[] args)
            {
                IConfiguration config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                var optionsBuilder = new DbContextOptionsBuilder<HotelListDBContext>();
                var conn = config.GetConnectionString("HotelListDB");
                optionsBuilder.UseSqlServer(conn);
                return new HotelListDBContext(optionsBuilder.Options);
            }
        }
    }
}
