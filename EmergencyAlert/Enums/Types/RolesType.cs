using System.Text.Json.Serialization;

namespace EmergencyAlert.Enums.Types
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ROLES_TYPE
    {
        CITIZEN,
        VOLUNTEER,
        EMERGENCY_SERIVCE,
        ADMIN

    }
}
