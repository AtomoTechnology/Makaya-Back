using Customer.services.queries.DTOs;
using Service.Common.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.services.queries.Interface
{
    public interface IUserQueryService
    {
        Task<DataCollection<UserDTO>> GetAllAsync(int page, int take, IEnumerable<Int64> users = null);
        Task<UserDTO> GetAsync(Int64 id);
    }
}
