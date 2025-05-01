namespace EmergencyAlert.Request
{
    public class AddUser
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }


    }
}
