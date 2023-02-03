using System;
using System.Collections.Generic;

namespace Web_Medical_API.models
{
    public partial class TMedicalItemPurchaseDetail
    {
        public long Id { get; set; }
        public long? MedicalItemPurchaseId { get; set; }
        public long? MedicalItemItem { get; set; }
        public int? Qty { get; set; }
        public long? MedicalFacilityId { get; set; }
        public long? CourirId { get; set; }
        public decimal? SubTotal { get; set; }
        public long CreateBy { get; set; }
        public DateTime CreateOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? DeleteBy { get; set; }
        public DateTime? DeleteOn { get; set; }
        public bool IsDelete { get; set; }
    }
}
