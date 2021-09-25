using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer.Domain
{
    public class User
    {
        #region Prperties
        public Int64 UserId { get; set; }
        public Int64 AccountId { get; set; }
        public Int64 ?LocationId { get; set; }
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public String EmailAddress { get; set; }
        public Int32? Gender { get; set; }
        public String Address { get; set; }
        public String NumberAddress { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? VoidedAt { get; set; }
        public Int32 state { get; set; }

        #endregion
        #region Relation
        [ForeignKey("LocationId")]
        public Location Location { get; set; }
        #endregion
    }
}
