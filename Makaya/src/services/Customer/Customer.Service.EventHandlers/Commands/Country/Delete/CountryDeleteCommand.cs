using MediatR;
using System;

namespace Customer.Service.EventHandlers.Commands.Country.Delete
{
    public class CountryDeleteCommand : INotification
    {
        #region Properties
        public Int64 CountryId { get; set; }
        public string CountryName { get; set; }
        #endregion
    }
}
