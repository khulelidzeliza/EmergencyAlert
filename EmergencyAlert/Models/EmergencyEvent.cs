using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmergencyAlert.Enums.Statuses;
using EmergencyAlert.Enums.Types;

namespace EmergencyAlert.Models
{
    public class EmergencyEvent
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public EVENT_TYPE EVENT_TYPE { get; set; } = EVENT_TYPE.None;
        public int Severity { get; set; } 
        public string Location { get; set; }
        public decimal AffectedRadius { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public ACTIVITY_STATUS ACTIVITY_STATUS { get; set; } = ACTIVITY_STATUS.ACTIVE;

        public Guid CreatedById { get; set; }
        public virtual User CreatedBy { get; set; }

        public virtual ICollection<EmergencyNotification> Notifications { get; set; }
        public virtual ICollection<ResourceAssignment> ResourceAssignments { get; set; }
        public virtual ICollection<VolunteerAssignment> VolunteerAssignments { get; set; }
    }
}

 