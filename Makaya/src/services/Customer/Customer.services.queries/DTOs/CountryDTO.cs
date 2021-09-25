using Customer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.services.queries.DTOs
{
    public class CountryDTO
    {
        #region Properties
        public Int64 CountryId { get; set; }
        public string CountryName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? VoidedAt { get; set; }
        public Int32 state { get; set; }
        #endregion

        #region List
        public List<LocationDTO> Location { get; set; }
        public List<ProvinceDTO> Province { get; set; }

        public static explicit operator CountryDTO(List<Country> v)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
