using EmergencyAlert.Enums.Statuses;
using EmergencyAlert.Enums.Types;
using EmergencyAlert.Models;

namespace EmergencyAlert.Request
{
    public class AddEmergencyEvent
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public EVENT_TYPE EVENT_TYPE { get; set; } = EVENT_TYPE.None;
        public int Severity { get; set; }
        public string Location { get; set; }
        public Guid CreatedById { get; set; }
        public decimal AffectedRadius { get; set; }
        public ACTIVITY_STATUS ACTIVITY_STATUS { get; set; } = ACTIVITY_STATUS.NONE;
    }
}
