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
    public class UserQueryService : IUserQueryService
    {
        private readonly ApplicationDbContext _context;
        public UserQueryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<DataCollection<UserDTO>> GetAllAsync(int page, int take, IEnumerable<long> users = null)
        {
            var collection = await _context.Users
                    .Where(x => (users == null || users.Contains(x.UserId)) && x.state == (Int32)StateEnum.Activeted)
                    .OrderBy(x => x.UserId)
                    .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<UserDTO>>();
        }

        public async Task<UserDTO> GetAsync(long id)
        {
            return (await _context.Users.SingleAsync(x => x.UserId == id && x.state == (Int32)StateEnum.Activeted)).MapTo<UserDTO>();
        }
    }
}
