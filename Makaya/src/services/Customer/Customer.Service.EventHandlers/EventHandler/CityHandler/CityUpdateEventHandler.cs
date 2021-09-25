using Customer.Service.EventHandlers.Commands.City;
using Customers.Persistence.DataBase;
using Makaya.Resolver.Enum;
using Makaya.Resolver.IExceptions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Service.EventHandlers.EventHandler.CityHandler
{
    public class CityUpdateEventHandler :
        INotificationHandler<CityUpdateCommand>
    {
        private readonly ApplicationDbContext _context;
        public CityUpdateEventHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(CityUpdateCommand comands, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context.Cities.FindAsync(comands.CityId);
                if (entity == null)
                    throw new ApiBusinessException((int)EnumCode.City, "This city does not exist", System.Net.HttpStatusCode.NotFound, "Http");

                var entitynone = _context.Cities.Where(x => x.CityName == comands.CityName && x.CityId != comands.CityId).ToList();
                if (entitynone.Count > 0)
                    throw new ApiBusinessException((int)EnumCode.City, "Another city with that name already exists, the update could not be completed.", System.Net.HttpStatusCode.NotFound, "Http");

                entity.ProvinceId = comands.ProvinceId;
                entity.CityName = comands.CityName;
                entity.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}