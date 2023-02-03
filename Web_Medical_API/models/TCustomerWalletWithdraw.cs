using System;
using System.Collections.Generic;

namespace Web_Medical_API.models
{
    public partial class TCustomerWalletWithdraw
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long? WalletDefaultNominalId { get; set; }
        public int Amount { get; set; }
        public string BankName { get; set; } = null!;
        public string AccountNumber { get; set; } = null!;
        public string AcoountName { get; set; } = null!;
        public int Otp { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeltedOn { get; set; }
        public bool IsDelete { get; set; }
    }
}
