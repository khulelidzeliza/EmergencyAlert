using System.ComponentModel.DataAnnotations;
using EmergencyAlert.Enums.Statuses;
using EmergencyAlert.Enums.Types;

namespace EmergencyAlert.Models
{
    public class Resource
    {
        [Key]
        public Guid Id { get; set; }    
        public string Name { get; set; }
        public string Description { get; set; }


        public RESOURCE_CATEGORY Cateory { get; set; } = RESOURCE_CATEGORY.PERSONNEL;
        public int Quantity { get; set; }


        public STATUS Status { get; set; } = STATUS.NONE;

        public virtual ICollection<ResourceAssignment> Assignments { get; set; }
    }
}
    