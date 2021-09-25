using Customer.Service.EventHandlers.Commands.Country.Delete;
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

namespace Customer.Service.EventHandlers.EventHandler.CountryHandlers.Delete
{
    public class CountryDeleteEventHandler :
        INotificationHandler<CountryDeleteCommand>
    {
        private readonly ApplicationDbContext _context;
        public CountryDeleteEventHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(CountryDeleteCommand comands, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context.Countries.FindAsync(comands.CountryId);
                if (entity == null)
                    throw new ApiBusinessException((int)EnumCode.Country, "This country does not exist", System.Net.HttpStatusCode.NotFound, "Http");

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
