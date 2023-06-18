using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_List_API.Data;
using Hotel_List_API.Models.Country;
using AutoMapper;
using Hotel_List_API.Contracts;
using Microsoft.AspNetCore.Authorization;
using Hotel_List_API.Exceptions;

namespace Hotel_List_API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class CountriesControllerVer2 : ControllerBase
    {
        //       private readonly HotelListDBContext _context;
        private readonly ICountryRepository _repoCountry;
        private readonly IMapper _mapper;

        public CountriesControllerVer2( IMapper mapper, ICountryRepository countryRepository)
        {
            _repoCountry = countryRepository;
            _mapper = mapper;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountryDTO>>> GetCountries()
        {
            var countries = await _repoCountry.GetAllAsync();
            var countriesDTO = _mapper.Map<List<GetCountryDTO>>(countries);
            return Ok(countriesDTO);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDetailDTO>> GetCountry(int id)
        {
            var country = await _repoCountry.GetDetails(id);

            if (country == null)
            {
                //  return NotFound();
                throw new NotFoundException(nameof(Country), id);
            }
            var record = _mapper.Map<CountryDetailDTO>(country);
            return Ok(record);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDTO updateCountryDTO)
        {
            if (id != updateCountryDTO.Id)
            {
                return BadRequest();
            }

            // _context.Entry(country).State = EntityState.Modified;
            var country = await _repoCountry.GetAsync(id);
            if (country == null)
            {
                //  return NotFound();
                throw new NotFoundException(nameof(Country), id);
            }
            _mapper.Map(updateCountryDTO, country);
            try
            {
                await _repoCountry.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Country>> PostCountry(CreateCountryDTO createCountry)
        {

            // use DTO
            //var country = new Country
            //{
            //      Name = createCountry.Name,
            //      ShortName = createCountry.ShortName
            //};

            // use AutoMapper
            var country = _mapper.Map<Country>(createCountry);

            await _repoCountry.AddAsync(country);

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCountry(int id)
        {

            var country = await _repoCountry.GetAsync(id);
            if (country == null)
            {
                //  return NotFound();
                throw new NotFoundException(nameof(Country), id);
            }

            await _repoCountry.DeleteAsync(id);
            return Ok();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await _repoCountry.Exists(id);
        }
    }
}
