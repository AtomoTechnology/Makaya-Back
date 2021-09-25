using Customer.services.queries.DTOs;
using Service.Common.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.services.queries.Interface
{
    public interface IProvinceQueryService
    {
        Task<DataCollection<ProvinceDTO>> GetAllAsync(int page, int take, Int64 CountryId, Boolean isFilter = false, IEnumerable<Int64> provinces = null);
        Task<ProvinceDTO> GetAsync(Int64 id);
    }
}
