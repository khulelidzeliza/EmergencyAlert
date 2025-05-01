using EmergencyAlert.Core;
using EmergencyAlert.Models;

namespace EmergencyAlert.Services.Interfaces; 

public interface IJWTService
{
    UserToken GetUserToken(User user);
}
