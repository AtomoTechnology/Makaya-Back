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
    public class ProvinceQueryService : IProvinceQueryService
    {
        private readonly ApplicationDbContext _context;
        public ProvinceQueryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<DataCollection<ProvinceDTO>> GetAllAsync(int page, int take, long CountryId, bool isFilter = false, IEnumerable<long> provinces = null)
        {
            if (!isFilter)
            {

                var collection = await _context.Provinces
                     .Where(x => (provinces == null || provinces.Contains(x.ProvinceId)) && x.state == (Int32)StateEnum.Activeted)
                     .OrderBy(x => x.ProvinceName)
                     .GetPagedAsync(page, take);

                return collection.MapTo<DataCollection<ProvinceDTO>>();
            }
            else
            {
                var collection = await _context.Provinces
                   .Where(x => (provinces == null || provinces.Contains(x.CountryId)) && x.state == (Int32)StateEnum.Activeted)
                   .OrderBy(x => x.ProvinceName)
                   .GetPagedAsync(1, 100000000);

                return collection.MapTo<DataCollection<ProvinceDTO>>();
            }
        }

        public async Task<ProvinceDTO> GetAsync(long id)
        {
            return (await _context.Provinces.SingleAsync(x => x.CountryId == id && x.state == (Int32)StateEnum.Activeted)).MapTo<ProvinceDTO>();
        }
    }
}
