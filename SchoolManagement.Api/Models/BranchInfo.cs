using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class BranchInfo
    {
        public BranchInfo()
        {
            Users = new HashSet<User>();
        }

        public int BranchInfoId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string ContactPerson { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public long? CountryCode { get; set; }
        public long? ZoneInfoIdentity { get; set; }
        public string BranchLevel { get; set; }
        public string FirstLevel { get; set; }
        public string SecondLevel { get; set; }
        public string ThirdLevel { get; set; }
        public string FourthLevel { get; set; }
        public string FifthLevel { get; set; }
        public string BranchType { get; set; }
        public string NativeBranchCode { get; set; }
        public long? CurrencyCode { get; set; }
        public string OwnBranchCode { get; set; }
        public int? UserId { get; set; }
        public string ServerName { get; set; }
        public string AccountNoFc { get; set; }
        public string AccountNoLc { get; set; }
        public decimal? MinimumCoverFund { get; set; }
        public byte? WorkingTimeFrom { get; set; }
        public byte? WorkingTimeTo { get; set; }
        public decimal? MinimumNrdbalance { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
