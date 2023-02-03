using System;
using System.Collections.Generic;

namespace Web_Medical_API.models
{
    public partial class MMedicalFacilitySchedule
    {
        public long Id { get; set; }
        public long? MedicalFacilityId { get; set; }
        public string? Day { get; set; }
        public string? TimeScheduleStart { get; set; }
        public string? TimeScheduleEnd { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeltedOn { get; set; }
        public bool IsDelete { get; set; }
    }
}
