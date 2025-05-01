using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmergencyAlert.Enums.Statuses;

namespace EmergencyAlert.Models
{
    public class UserNotification
    {
        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid NotificationId { get; set; }
        public bool IsRead { get; set; }

        public DELIVERY_STATUS DeliveryStatus { get; set; } = DELIVERY_STATUS.NONE;

        public virtual User User { get; set; }

        public virtual EmergencyNotification Notification { get; set; }
    }
}
 