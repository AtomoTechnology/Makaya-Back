using Customer.Domain;
using Customer.Service.EventHandlers.Commands.Province;
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

namespace Customer.Service.EventHandlers.EventHandler.ProvinceHandler
{
    public class ProvinceCreateEventHandler :
        INotificationHandler<ProvinceCreateCommand>
    {
        private readonly ApplicationDbContext _context;
        public ProvinceCreateEventHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ProvinceCreateCommand comands, CancellationToken cancellationToken)
        {
            try
            {
                var entity =  _context.Provinces.Where(x => x.ProvinceName == comands.ProvinceName).ToList();
                if (entity.Count > 0)
                    throw new ApiBusinessException((int)EnumCode.Province, "Province exists", System.Net.HttpStatusCode.NotFound, "Http");

                if (comands.CountryId == 0 || comands.CountryId == null)
                    throw new ApiBusinessException((int)EnumCode.Province, "Country name required", System.Net.HttpStatusCode.NotFound, "Http");

                if (String.IsNullOrEmpty(comands.ProvinceName))
                    throw new ApiBusinessException((int)EnumCode.Province, "Province name required", System.Net.HttpStatusCode.NotFound, "Http");

                await _context.AddAsync(new Province
                {
                    CountryId = comands.CountryId,
                    ProvinceName = comands.ProvinceName,
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
