using EmergencyAlert.Enums.Statuses;

namespace EmergencyAlert.DTO
{
    public class UpdateVolunteerDto
    {
        public string Skills { get; set; }
        public AVAILABILITY_STATUS AvailabilityStatus { get; set; }
        public string EmergencyContactPone { get; set; }
    }
}
