using System;
using System.Collections.Generic;

namespace Web_Medical_API.models
{
    public partial class TAppointmentRescheduleHistory
    {
        public long Id { get; set; }
        public long? AppointmentId { get; set; }
        public long? DoctorOfficeScheduleId { get; set; }
        public long? DoctorOfficeTreatmentId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDelete { get; set; }
    }
}
