using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Service.EventHandlers.Commands.Province
{
    public class ProvinceBase : INotification
    {
        #region Properties
        public Int64 ProvinceId { get; set; }
        public Int64 CountryId { get; set; }
        public string ProvinceName { get; set; }
        #endregion
    }
}
