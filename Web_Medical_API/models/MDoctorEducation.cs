using System;
using System.Collections.Generic;

namespace Web_Medical_API.models
{
    public partial class MDoctorEducation
    {
        public long Id { get; set; }
        public long? DoctorId { get; set; }
        public long? EducationLevelId { get; set; }
        public string? InstitutionName { get; set; }
        public string? Major { get; set; }
        public string? StartYear { get; set; }
        public string? EndYear { get; set; }
        public bool? IsLastEducation { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeltedOn { get; set; }
        public bool IsDelete { get; set; }
    }
}
