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
    public class CityQueryService : ICityQueryService
    {
        private readonly ApplicationDbContext _context;
        public CityQueryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<DataCollection<CityDTO>> GetAllAsync(int page, int take, long ProvinceId, bool isFilter = false, IEnumerable<long> cities = null)
        {
            if (!isFilter)
            {
                var collection = await _context.Cities
                .Where(x => (cities == null || cities.Contains(x.CityId)) && x.state == (Int32)StateEnum.Activeted)
                .OrderBy(x => x.CityName)
                .GetPagedAsync(page, take);

                return collection.MapTo<DataCollection<CityDTO>>();
            }
            else
            {
                var collection = await _context.Cities
                   .Where(x => (cities == null || cities.Contains(x.ProvinceId)) && x.state == (Int32)StateEnum.Activeted)
                   .OrderBy(x => x.CityName)
                   .GetPagedAsync(1, 100000000);

                return collection.MapTo<DataCollection<CityDTO>>();
            }
        }

        public async Task<CityDTO> GetAsync(long id)
        {
            return (await _context.Provinces.SingleAsync(x => x.CountryId == id && x.state == (Int32)StateEnum.Activeted)).MapTo<CityDTO>();
        }
    }
}
