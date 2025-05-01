using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmergencyAlert.Enums.Statuses;

namespace EmergencyAlert.Models
{
    public class Volunteer
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Skills { get; set; }
        public AVAILABILITY_STATUS AvailabilityStatus { get; set; } = AVAILABILITY_STATUS.AVAILABLE;

        public string EmergencyContactPhone { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<VolunteerAssignment> Assignments { get; set; }
    }
}
