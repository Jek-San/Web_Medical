﻿using System;
using System.Collections.Generic;

namespace Web_Medical_API.models
{
    public partial class MSpecialization
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDelete { get; set; }
    }
}
