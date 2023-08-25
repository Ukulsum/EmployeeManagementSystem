using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystemProject.Models
{
    public class Qualification
    {
        [Key]
        public int QualiId { get; set; }

        [DisplayName("Qualification")]
        public string QualificationName { get; set; }
    }
}
