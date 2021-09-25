using Customer.services.queries.DTOs;
using Customer.services.queries.Interface;
using Customers.Persistence.DataBase;
using Makaya.Resolver.Eum;
using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.services.queries.Queries
{
    public class CountryQueryService: ICountryQueryService
    {
        private readonly ApplicationDbContext _context;
        public CountryQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DataCollection<CountryDTO>> GetAllAsync(int page, int take, bool isFilter = false, IEnumerable<Int64> countries = null)
        {
            if (!isFilter)
            {
                var collection = await _context.Countries
                    .Where(x => (countries == null || countries.Contains(x.CountryId)) && x.state == (Int32)StateEnum.Activeted)
                    .OrderBy(x => x.CountryName)
                    .GetPagedAsync(page, take);

                return collection.MapTo<DataCollection<CountryDTO>>();
            }
            else
            {
                var collection = await _context.Countries
                   .Where(x => (countries == null || countries.Contains(x.CountryId)) && x.state == (Int32)StateEnum.Activeted)
                   .OrderBy(x => x.CountryName)
                   .GetPagedAsync(1, 100000000);

                return collection.MapTo<DataCollection<CountryDTO>>();
            }
        }
        public async Task<CountryDTO> GetAsync(Int64 id)
        {
            return (await _context.Countries.SingleAsync(x => x.CountryId == id && x.state == (Int32)StateEnum.Activeted)).MapTo<CountryDTO>();
        }
    }
}
