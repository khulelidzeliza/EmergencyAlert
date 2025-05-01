using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmergencyAlert.Enums.Statuses;

namespace EmergencyAlert.Models
{
    public class ResourceAssignment
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid ResourceId { get; set; }
        public Guid EmergencyEventId { get; set; }
        public Guid AssignedById { get; set; }
        public DateTime AssignedTime { get; set; }
        public DateTime? ReturnedTime { get; set; }

        public STATUS2 Status { get; set; } = STATUS2.NONE;

   
        public virtual Resource Resource { get; set; }

        public virtual EmergencyEvent EmergencyEvent { get; set; }

        public virtual User AssignedBy { get; set; }
    }
}


 