using Customer.Service.EventHandlers.Commands.Province;
using Customer.Service.EventHandlers.Commands.User;
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

namespace Customer.Service.EventHandlers.EventHandler.UserHandler
{
    public class UserDeleteEventHandler :
        INotificationHandler<UserDeleteCommand>
    {
        private readonly ApplicationDbContext _context;
        public UserDeleteEventHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UserDeleteCommand notification, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context.Users.FindAsync(notification.UserId);
                if (entity == null)
                    throw new ApiBusinessException((int)EnumCode.User, "User does not exist", System.Net.HttpStatusCode.NotFound, "Http");

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
