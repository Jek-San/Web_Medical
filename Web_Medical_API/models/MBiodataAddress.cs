using System;
using System.Collections.Generic;

namespace Web_Medical_API.models
{
    public partial class MBiodataAddress
    {
        public long Id { get; set; }
        public long? BiodataId { get; set; }
        public string? Label { get; set; }
        public string? Recipient { get; set; }
        public string? RecipientPhoneNumber { get; set; }
        public long? LocationId { get; set; }
        public string? PostalCode { get; set; }
        public string? Address { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDelete { get; set; }
    }
}
