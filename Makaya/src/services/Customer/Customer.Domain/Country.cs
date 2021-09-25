using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain
{
    public class Country
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
        public List<Location> Location { get; set; }
        public List<Province> Province { get; set; }
        #endregion
    }
}
