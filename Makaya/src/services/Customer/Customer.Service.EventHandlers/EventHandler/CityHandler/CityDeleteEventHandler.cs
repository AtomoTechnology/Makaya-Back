using Customer.Service.EventHandlers.Commands.City;
using Customers.Persistence.DataBase;
using Makaya.Resolver.Enum;
using Makaya.Resolver.Eum;
using Makaya.Resolver.IExceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Service.EventHandlers.EventHandler.CityHandler
{
    public class CityDeleteEventHandler :
        INotificationHandler<CityDeleteCommand>
    {
        private readonly ApplicationDbContext _context;
        public CityDeleteEventHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(CityDeleteCommand comands, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context.Cities.FindAsync(comands.CityId);
                if (entity == null)
                    throw new ApiBusinessException((int)EnumCode.City, "This city does not exist", System.Net.HttpStatusCode.NotFound, "Http");

                entity.state = (Int32)StateEnum.Deleted;
                entity.VoidedAt = DateTime.Now;

                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}