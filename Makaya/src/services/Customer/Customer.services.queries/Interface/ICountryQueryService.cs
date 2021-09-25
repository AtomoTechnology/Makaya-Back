using Customer.services.queries.DTOs;
using Service.Common.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.services.queries.Interface
{
    public interface ICountryQueryService
    {
        Task<DataCollection<CountryDTO>> GetAllAsync(int page, int take, Boolean isFilter = false, IEnumerable<Int64> countries = null);
        Task<CountryDTO> GetAsync(Int64 id);
    }
}
