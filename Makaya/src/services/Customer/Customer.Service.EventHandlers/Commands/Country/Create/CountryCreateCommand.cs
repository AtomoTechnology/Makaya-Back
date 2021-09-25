using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Service.EventHandlers.Commands.Country.Create
{
    public class CountryCreateCommand : INotification
    {
        #region Properties
        public Int64 CountryId { get; set; }
        public string CountryName { get; set; }
        #endregion
    }
}
