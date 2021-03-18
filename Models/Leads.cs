using System;
using System.Collections.Generic;

namespace BuildingApi.Models
{
    public partial class Leads
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string ProjectName { get; set; }
        public string Department { get; set; }
        public string ProjectDescription { get; set; }
        public string Message { get; set; }
        public byte[] FileAttachment { get; set; }
        public DateTime created_at { get; set; }
        public string Filename { get; set; }
        public long? customers_id { get; set; }

        public virtual Customers Customers { get; set; }
    }
}
