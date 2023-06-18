﻿using AutoMapper;
using Hotel_List_API.Contracts;
using Hotel_List_API.Data;

namespace Hotel_List_API.Repository
{
    public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        private readonly HotelListDBContext _context;

        public HotelRepository(HotelListDBContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
