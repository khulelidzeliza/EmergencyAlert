namespace EmergencyAlert.DTO
{
    public class EmEventDetailDto
    {
        public string Description { get; set; }
        public int? Severity { get; set; }
        public decimal? AffectedRadius { get; set; }
        public DateTime? EndTime { get; set; }
        public string Status { get; set; }
    }
}
