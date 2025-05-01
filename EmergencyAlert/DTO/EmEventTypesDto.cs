using EmergencyAlert.Enums.Statuses;
using EmergencyAlert.Enums.Types;

namespace EmergencyAlert.DTO
{
    public class EmEventTypesDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public EVENT_TYPE EVENT_TYPE { get; set; } = EVENT_TYPE.FIRE;
        public ACTIVITY_STATUS ACTIVITY_STATUS { get; set; } = ACTIVITY_STATUS.ACTIVE;

    }


}

