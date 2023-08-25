using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystemProject.Models
{
    public class Designation
    {
        [Key]
        public int DesignationId { get; set; }

        [Required]
        [DisplayName("Designation Name")]
        public string DesignationName { get; set; }
    }
}
