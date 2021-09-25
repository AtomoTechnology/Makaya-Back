using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Service.EventHandlers.Commands.Country.Update
{
    public class CountryUpdateCommand : INotification
    {
        #region Properties
        public Int64 CountryId { get; set; }
        public string CountryName { get; set; }
        #endregion
    }
}
