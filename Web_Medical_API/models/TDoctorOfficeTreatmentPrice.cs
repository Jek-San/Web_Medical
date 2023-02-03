using System;
using System.Collections.Generic;

namespace Web_Medical_API.models
{
    public partial class TDoctorOfficeTreatmentPrice
    {
        public long Id { get; set; }
        public long? DoctorOfficeTreatmentId { get; set; }
        public decimal? Price { get; set; }
        public decimal? PriceStartFrom { get; set; }
        public decimal? PriceUntilFrom { get; set; }
        public long CreateBy { get; set; }
        public DateTime CreateOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? DeleteBy { get; set; }
        public DateTime? DeleteOn { get; set; }
        public bool IsDelete { get; set; }
    }
}
