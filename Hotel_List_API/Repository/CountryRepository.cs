using Hotel_List_API.Contracts;
using Hotel_List_API.Data;
using Microsoft.EntityFrameworkCore;

namespace Hotel_List_API.Repository
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        private readonly HotelListDBContext _context;

        public CountryRepository(HotelListDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Country> GetDetails(int id)
        {
            return await _context.Countries.Include(q => q.Hotels)
                .SingleOrDefaultAsync(q => q.Id == id);
        }
    }
}
