using System;
using System.Collections.Generic;

namespace Web_Medical_API.models
{
    public partial class TPrescription
    {
        public long Id { get; set; }
        public long? AppointmentId { get; set; }
        public long? MedicalItemId { get; set; }
        public string? Dosage { get; set; }
        public string? Direction { get; set; }
        public string? Time { get; set; }
        public string? Notes { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeltedOn { get; set; }
        public bool IsDelete { get; set; }
    }
}
