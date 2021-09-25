using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain
{
    public class Location
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
        public City City { get; set; }
        public Country Country { get; set; }
        public Province Provinces { get; set; }
        #endregion

        #region List
        public List<User> User { get; set; }
        #endregion
    }
}
