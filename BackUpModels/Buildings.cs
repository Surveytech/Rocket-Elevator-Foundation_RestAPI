using System;
using System.Collections.Generic;

namespace BuildingApi.Models
{
    public partial class Buildings
    {
        public Buildings()
        {
            addresses = new HashSet<Addresses>();
            Batteries = new HashSet<Batteries>();
            BuildingDetails = new HashSet<BuildingDetails>();
        }

        public long Id { get; set; }
        public string AdmContactFullName { get; set; }
        public string AdmContactEmail { get; set; }
        public string AdmContactPhone { get; set; }
        public string TechContactFullName { get; set; }
        public string TechContactEmail { get; set; }
        public string TechContactPhone { get; set; }
        public long? CustomerId { get; set; }
        public long? AddressId { get; set; }

        public virtual Addresses address { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual ICollection<Addresses> addresses { get; set; }
        public virtual ICollection<Batteries> Batteries { get; set; }
        public virtual ICollection<BuildingDetails> BuildingDetails { get; set; }
    }
}
