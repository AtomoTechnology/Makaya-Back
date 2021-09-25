﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.services.queries.DTOs
{
    public class CityDTO
    {
        #region Properties
        public Int64 CityId { get; set; }
        public Int64 ProvinceId { get; set; }
        public string CityName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Int32 state { get; set; }
        #endregion

        #region Relation
        public ProvinceDTO Provinces { get; set; }
        #endregion

        #region List
        public List<LocationDTO> Location { get; set; }
        #endregion
    }
}
