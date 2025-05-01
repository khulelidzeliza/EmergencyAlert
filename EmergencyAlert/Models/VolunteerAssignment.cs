using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmergencyAlert.Enums.Statuses;
using EmergencyAlert.Models;

namespace EmergencyAlert.Models
{
    public class VolunteerAssignment
    {
        [Key]
        public Guid Id { get; set; }

        public Guid VolunteerId { get; set; }
        public Guid EmergencyEventId { get; set; }
        public Guid AssignedById { get; set; }
        public DateTime AssignedTime { get; set; }
        public DateTime CompletedTime { get; set; }
        public STATUS3 Status { get; set; } = STATUS3.ACCEPTED;

        public virtual Volunteer Volunteer { get; set; }

        public virtual EmergencyEvent EmergencyEvent { get; set; }

        public virtual User AssignedBy { get; set; }

    }
}
