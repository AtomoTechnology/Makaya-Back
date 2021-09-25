using Customer.Domain;
using Customer.Service.EventHandlers.Commands.Country.Create;
using Customers.Persistence.DataBase;
using Makaya.Resolver.Enum;
using Makaya.Resolver.Eum;
using Makaya.Resolver.IExceptions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Service.EventHandlers.CountryHandlers.Create
{
    public class CountryCreateEventHandler :
        INotificationHandler<CountryCreateCommand>
    {
        private readonly ApplicationDbContext _context;
        public CountryCreateEventHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(CountryCreateCommand comands, CancellationToken cancellationToken)
        {
            try
            {
                if (String.IsNullOrEmpty(comands.CountryName))
                    throw new ApiBusinessException((int)EnumCode.Country, "Country name required", System.Net.HttpStatusCode.NotFound, "Http");

                var entity =  _context.Countries.Where(x =>  x.CountryName == comands.CountryName).ToList();
                if (entity.Count > 0)
                    throw new ApiBusinessException(100, "Country exists", System.Net.HttpStatusCode.NotFound, "Http");

                await _context.AddAsync(new Country
                {
                    CountryName = comands.CountryName,
                    state = (Int32)StateEnum.Activeted,
                    CreatedAt = DateTime.Now
                });

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
