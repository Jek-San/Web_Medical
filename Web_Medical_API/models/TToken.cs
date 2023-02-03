using System;
using System.Collections.Generic;

namespace Web_Medical_API.models
{
    public partial class TToken
    {
        public long Id { get; set; }
        public string? Email { get; set; }
        public long? UserId { get; set; }
        public string? Token { get; set; }
        public DateTime? ExpiredOn { get; set; }
        public bool? IsExpired { get; set; }
        public string? UsedFor { get; set; }
        public long CreateBy { get; set; }
        public DateTime CreateOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? DeleteBy { get; set; }
        public DateTime? DeleteOn { get; set; }
        public bool IsDelete { get; set; }
    }
}
