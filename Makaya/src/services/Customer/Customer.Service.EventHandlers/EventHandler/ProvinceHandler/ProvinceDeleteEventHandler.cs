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
    public class ProvinceDeleteEventHandler :
        INotificationHandler<ProvinceDeleteCommand>
    {
        private readonly ApplicationDbContext _context;
        public ProvinceDeleteEventHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ProvinceDeleteCommand comands, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context.Provinces.FindAsync(comands.ProvinceId);
                if (entity == null)
                    throw new ApiBusinessException((int)EnumCode.Province, "This Province does not exist", System.Net.HttpStatusCode.NotFound, "Http");

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
