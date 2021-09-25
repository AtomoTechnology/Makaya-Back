using Customer.Domain;
using Customer.Service.EventHandlers.Commands.User;
using Customers.Persistence.DataBase;
using Makaya.Resolver.Enum;
using Makaya.Resolver.Eum;
using Makaya.Resolver.IExceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Service.EventHandlers.EventHandler.UserHandler
{
    public class UserCreateEventHandler :
        INotificationHandler<UserCreateCommand>
    {
        private readonly ApplicationDbContext _context;
        public UserCreateEventHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UserCreateCommand comands, CancellationToken cancellationToken)
        {
            try
            {
                if (comands.AccountId == 0 || comands.AccountId == null)
                    throw new ApiBusinessException((int)EnumCode.User, "Id account user required", System.Net.HttpStatusCode.NotFound, "Http");
                if (String.IsNullOrEmpty(comands.Firstname))
                    throw new ApiBusinessException((int)EnumCode.User, "Firstname required", System.Net.HttpStatusCode.NotFound, "Http");
                if (String.IsNullOrEmpty(comands.Lastname))
                    throw new ApiBusinessException((int)EnumCode.User, "Lastname required", System.Net.HttpStatusCode.NotFound, "Http");
                if (comands.Location == null)
                    throw new ApiBusinessException((int)EnumCode.User, "Location user required", System.Net.HttpStatusCode.NotFound, "Http");
                if (comands.Location.CountryId == 0 || comands.Location.CountryId == null)
                    throw new ApiBusinessException((int)EnumCode.User, "Country required", System.Net.HttpStatusCode.NotFound, "Http");
                if (comands.Location.ProvinceId == 0 || comands.Location.ProvinceId == null)
                    throw new ApiBusinessException((int)EnumCode.User, "Province required", System.Net.HttpStatusCode.NotFound, "Http");
                if (comands.Location.CityId == 0 || comands.Location.CityId == null)
                    throw new ApiBusinessException((int)EnumCode.User, "City required", System.Net.HttpStatusCode.NotFound, "Http");
              

                await _context.AddAsync( new Location {
                    CityId = comands.Location.CityId,
                    ProvinceId = comands.Location.ProvinceId,
                    CountryId = comands.Location.CountryId,
                    CreatedAt = DateTime.Now,
                    state = (Int32)StateEnum.Activeted,
                    User = new List<User> {
                         new User
                        {
                            AccountId = comands.AccountId,
                            LocationId = comands.LocationId,
                            Firstname = comands.Firstname,
                            Lastname = comands.Lastname,
                            EmailAddress = comands.EmailAddress,
                            Gender = comands.Gender,
                            Address = comands.Address,
                            NumberAddress = comands.NumberAddress,
                            DateOfBirth = comands.DateOfBirth,
                            state = (Int32)StateEnum.Activeted,
                            CreatedAt = DateTime.Now
                        }
                    }
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