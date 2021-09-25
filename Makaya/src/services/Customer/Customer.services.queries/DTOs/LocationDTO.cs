using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.services.queries.DTOs
{
    public class LocationDTO
    {
        #region Properties
        public Int64 LocationId { get; set; }
        public Int64 CountryId { get; set; }
        public Int64 ProvinceId { get; set; }
        public Int64 CityId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Int32 state { get; set; }

        #endregion

        #region Relation
        public CityDTO City { get; set; }
        public CountryDTO Country { get; set; }
        public ProvinceDTO Provinces { get; set; }
        #endregion
    }
}
