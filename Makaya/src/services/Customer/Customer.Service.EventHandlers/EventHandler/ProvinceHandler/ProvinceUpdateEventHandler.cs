using Customer.Service.EventHandlers.Commands.Province;
using Customers.Persistence.DataBase;
using Makaya.Resolver.Enum;
using Makaya.Resolver.IExceptions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Service.EventHandlers.EventHandler.ProvinceHandler
{
    public class ProvinceUpdateEventHandler :
        INotificationHandler<ProvinceUpdateCommand>
    {
        private readonly ApplicationDbContext _context;
        public ProvinceUpdateEventHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ProvinceUpdateCommand comands, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context.Provinces.FindAsync(comands.ProvinceId);
                if (entity == null)
                    throw new ApiBusinessException((int)EnumCode.Province, "This province does not exist", System.Net.HttpStatusCode.NotFound, "Http");

                var entitynone = _context.Provinces.Where(x => x.ProvinceName == comands.ProvinceName && x.ProvinceId != comands.ProvinceId).ToList();
                if (entitynone.Count > 0)
                    throw new ApiBusinessException((int)EnumCode.Province, "Another province with that name already exists, the update could not be completed.", System.Net.HttpStatusCode.NotFound, "Http");

                entity.ProvinceName = comands.ProvinceName;
                entity.CountryId = comands.CountryId;
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
