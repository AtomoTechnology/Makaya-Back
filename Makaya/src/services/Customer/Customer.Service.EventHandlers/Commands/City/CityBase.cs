using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Service.EventHandlers.Commands.City
{
    public class CityBase : INotification
    {
        #region Properties
        public Int64 CityId { get; set; }
        public Int64 ProvinceId { get; set; }
        public string CityName { get; set; }
        #endregion
    }
}
