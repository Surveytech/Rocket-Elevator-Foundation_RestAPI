using System;
using System.Collections.Generic;

namespace BuildingApi.Models
{
    public partial class Employees
    {
        public Employees()
        {
            Batteries = new HashSet<Batteries>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Function { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public long? UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Batteries> Batteries { get; set; }
    }
}
