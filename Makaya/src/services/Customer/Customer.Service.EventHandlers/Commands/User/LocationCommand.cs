using System;

namespace Customer.Service.EventHandlers.Commands.User
{
    public class LocationCommand
    {
        public Int64 LocationId { get; set; }
        public Int64 CountryId { get; set; }
        public Int64 ProvinceId { get; set; }
        public Int64 CityId { get; set; }
    }
}
