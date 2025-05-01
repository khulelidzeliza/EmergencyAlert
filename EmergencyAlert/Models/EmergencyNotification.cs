using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmergencyAlert.Enums.Types;

namespace EmergencyAlert.Models
{
    public class EmergencyNotification
    {
        [Key]
        public Guid Id { get; set; }

        public Guid EmergencyEventId { get; set; }

        public string Message { get; set; }
        public DateTime SentTime { get; set; }

        public NOTIFICATION_TYPE NotificationType { get; set; } = NOTIFICATION_TYPE.NONE;

        public virtual EmergencyEvent EmergencyEvent { get; set; }

        public virtual ICollection<UserNotification> UserNotifications { get; set; }
    }
}


 