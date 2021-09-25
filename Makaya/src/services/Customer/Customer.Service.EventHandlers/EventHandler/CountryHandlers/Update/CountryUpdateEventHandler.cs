using Customer.Service.EventHandlers.Commands.Country.Update;
using Customer.Service.EventHandlers.Commands.Province;
using Customers.Persistence.DataBase;
using Makaya.Resolver.Enum;
using Makaya.Resolver.IExceptions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Service.EventHandlers.CountryHandlers.Update
{
    public class CountryUpdateEventHandler :
        INotificationHandler<CountryUpdateCommand>
    {
        private readonly ApplicationDbContext _context;
        public CountryUpdateEventHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(CountryUpdateCommand comands, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context.Countries.FindAsync(comands.CountryId);
                if(entity == null)
                    throw new ApiBusinessException((int)EnumCode.Country, "This country does not exist", System.Net.HttpStatusCode.NotFound, "Http");

                var entitynone = _context.Countries.Where(x => x.CountryName == comands.CountryName && x.CountryId != comands.CountryId).ToList();
                if (entitynone.Count > 0)
                    throw new ApiBusinessException((int)EnumCode.Country, "Another country with that name already exists, the update could not be completed.", System.Net.HttpStatusCode.NotFound, "Http");

                entity.CountryName = comands.CountryName;
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