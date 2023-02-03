﻿using System;
using System.Collections.Generic;

namespace Web_Medical_API.models
{
    public partial class MMedicalFacility
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public long? MedicalFacilityCategoryId { get; set; }
        public long? LocationId { get; set; }
        public string? FullAddress { get; set; }
        public string? Email { get; set; }
        public string? PhoneCode { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeltedOn { get; set; }
        public bool IsDelete { get; set; }
    }
}
