using MediatR;
using System;

namespace Customer.Service.EventHandlers.Commands.User
{
    public class UserBase : INotification
    {
        #region Prperties
        public Int64 UserId { get; set; }
        public Int64 AccountId { get; set; }
        public Int64? LocationId { get; set; }
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public String EmailAddress { get; set; }
        public Int32? Gender { get; set; }
        public String Address { get; set; }
        public String NumberAddress { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public LocationCommand Location { get; set; }
        #endregion
    }
}
