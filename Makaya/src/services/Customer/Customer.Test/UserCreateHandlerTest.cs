using Customer.Service.EventHandlers.Commands.User;
using Customer.Service.EventHandlers.EventHandler.UserHandler;
using Customer.Test.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Customer.Test
{
    [TestClass]
    public class UserCreateHandlerTest
    {
        [TestMethod]
        public void TryCreateUserFalse()
        {
            var context = ApplicationDbContextInMemory.Get();
            var comand = new UserCreateEventHandler(context);

            var AccountId = 2;
            UserCreateCommand user = new UserCreateCommand()
            {
                AccountId = AccountId,
                UserId= 1,
	            LocationId=1,
                Firstname="Pradel",
                Lastname= "Eugene",
                EmailAddress = "prade516@gmail.com",
                Gender = 1,
                Address = "España",
                NumberAddress = "1080 piso 2 Depto A",
                DateOfBirth = System.DateTime.Now,
                Location = new LocationCommand{
                    CityId = 1,
                    ProvinceId = 1,
                    CountryId = 2
                }
            };
           comand.Handle(user, new System.Threading.CancellationToken()).Wait();
           Assert.AreEqual(context.Users.Single(x => x.AccountId == AccountId).AccountId, 3);
        }
        [TestMethod]
        public void TryCreateUserTrue()
        {
            var context = ApplicationDbContextInMemory.Get();
            var comand = new UserCreateEventHandler(context);

            var AccountId = 2;
            UserCreateCommand user = new UserCreateCommand()
            {
                AccountId = AccountId,
                UserId = 1,
                LocationId = 1,
                Firstname = "Pradel",
                Lastname = "Eugene",
                EmailAddress = "prade516@gmail.com",
                Gender = 1,
                Address = "España",
                NumberAddress = "1080 piso 2 Depto A",
                DateOfBirth = System.DateTime.Now,
                Location = new LocationCommand
                {
                    CityId = 1,
                    ProvinceId = 1,
                    CountryId = 2
                }
            };
            comand.Handle(user, new System.Threading.CancellationToken()).Wait();
            Assert.AreEqual(context.Users.Single(x => x.AccountId == AccountId).AccountId, 2);
        }
    }
}
