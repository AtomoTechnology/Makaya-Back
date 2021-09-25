using Customer.Domain;
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
    public class CityCreateEventHandler: INotificationHandler<CityCreateCommand>
    {
        private readonly ApplicationDbContext _context;
        public CityCreateEventHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(CityCreateCommand comands, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _context.Cities.Where(x => x.CityName == comands.CityName).ToList();
                if (entity.Count > 0)
                    throw new ApiBusinessException((int)EnumCode.Province, "City exists", System.Net.HttpStatusCode.NotFound, "Http");
                if (comands.ProvinceId == 0 || comands.ProvinceId == null)
                    throw new ApiBusinessException((int)EnumCode.City, "Country Province name required", System.Net.HttpStatusCode.NotFound, "Http");

                if (String.IsNullOrEmpty(comands.CityName))
                    throw new ApiBusinessException((int)EnumCode.City, "City name required", System.Net.HttpStatusCode.NotFound, "Http");

                await _context.AddAsync(new City
                {
                    ProvinceId = comands.ProvinceId,
                    CityName = comands.CityName,
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
