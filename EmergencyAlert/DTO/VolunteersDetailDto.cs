namespace EmergencyAlert.DTO
{
    public class VolunteersDetailDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Skills { get; set; }
        public string AvailabilityStatus { get; set; }
        public string EmergencyContactPhone { get; set; }

        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
    }
}
