using EmergencyAlert.Enums.Statuses;

namespace EmergencyAlert.Request
{
    public class AddVolunteer
    {
        public Guid UserId { get; set; }
        public string Skills { get; set; }
        public AVAILABILITY_STATUS AvailabilityStatus { get; set; } = AVAILABILITY_STATUS.AVAILABLE;
        public string EmergencyContactPone { get; set; }
    }
}
