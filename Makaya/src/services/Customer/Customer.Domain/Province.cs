using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain
{
    public class Province
    {
        #region Properties
        public Int64 ProvinceId { get; set; }
        public Int64 CountryId { get; set; }
        public string ProvinceName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? VoidedAt { get; set; }
        public Int32 state { get; set; }
        #endregion

        #region Relation
        public Country Country { get; set; }
        #endregion

        #region List
        public List<City> City { get; set; }
        public List<Location> Location { get; set; }
        #endregion
    }
}
