using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class Trade
    {
        public Trade()
        {
            CallibrationStates = new HashSet<CallibrationState>();
            Demands = new HashSet<Demand>();
            ItemDetails = new HashSet<ItemDetail>();
            MaintenenceStates = new HashSet<MaintenenceState>();
            MeaSquadronStates = new HashSet<MeaSquadronState>();
        }

        public int TradeId { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
        public bool? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<CallibrationState> CallibrationStates { get; set; }
        public virtual ICollection<Demand> Demands { get; set; }
        public virtual ICollection<ItemDetail> ItemDetails { get; set; }
        public virtual ICollection<MaintenenceState> MaintenenceStates { get; set; }
        public virtual ICollection<MeaSquadronState> MeaSquadronStates { get; set; }
    }
}
