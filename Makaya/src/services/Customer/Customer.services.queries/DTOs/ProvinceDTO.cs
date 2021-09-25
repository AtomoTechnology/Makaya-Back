using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.services.queries.DTOs
{
    public class ProvinceDTO
    {
        #region Properties
        public Int64 ProvinceId { get; set; }
        public Int64 CountryId { get; set; }
        public string ProvinceName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Int32 state { get; set; }
        #endregion

        #region Relation
        public CountryDTO Country { get; set; }
        #endregion

        #region List
        public List<CityDTO> City { get; set; }
        public List<LocationDTO> Location { get; set; }
        #endregion
    }
}
