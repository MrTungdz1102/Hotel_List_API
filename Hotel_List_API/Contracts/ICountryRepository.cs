﻿using Hotel_List_API.Data;

namespace Hotel_List_API.Contracts
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        Task<Country> GetDetails(int id);
    }
}
