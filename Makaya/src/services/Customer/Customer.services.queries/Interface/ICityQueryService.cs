using Customer.services.queries.DTOs;
using Service.Common.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.services.queries.Interface
{
    public interface ICityQueryService
    {
        Task<DataCollection<CityDTO>> GetAllAsync(int page, int take, Int64 ProvinceId, Boolean isFilter = false, IEnumerable<Int64> cities = null);
        Task<CityDTO> GetAsync(Int64 id);
    }
}
