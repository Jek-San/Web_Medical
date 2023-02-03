using System;
using System.Collections.Generic;

namespace Web_Medical_API.models
{
    public partial class TCustomerWallet
    {
        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public string? Pin { get; set; }
        public decimal? Balance { get; set; }
        public string? Barcode { get; set; }
        public decimal? Points { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDelete { get; set; }
    }
}
