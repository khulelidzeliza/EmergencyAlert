using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using EmergencyAlert.Enums.Statuses;
using EmergencyAlert.Enums.Types;

namespace EmergencyAlert.Models;

public class User
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string HashedPassword { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    public string Location { get; set; }
    public string? verificationCode { get; set; }
    [Required]
    public ROLES_TYPE Role { get; set; } = ROLES_TYPE.CITIZEN;
    public ACCOUNT_STATUS status { get; set; } = ACCOUNT_STATUS.CODE_SENT;
    public bool isEmailVerified { get; set; }
    public DateTime RegistrationTime { get; set; } = DateTime.UtcNow;


    public virtual Volunteer Volunteer { get; set; }
    public virtual ICollection<UserNotification> UserNotifications { get; set; }
    public virtual ICollection<EmergencyEvent> CreatedEvents { get; set; }
    public virtual ICollection<ResourceAssignment> ResourceAssignments { get; set; }
    public virtual ICollection<VolunteerAssignment> VolunteerAssignments { get; set; }
}

