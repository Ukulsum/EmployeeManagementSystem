using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystemProject.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }

        [Required]
        [DisplayName("Name")]
        public string EmpName { get; set; }

        [ForeignKey("Designation")]
        public int DesignationId { get; set; }

        public string Photo { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public string Gender { get; set; }

        [ForeignKey("Qualification")]
        public int QualificationId { get; set; }

        [DisplayName("Date Of Birth")]
        public DateTime DOB { get; set; }

        [DisplayName("Contact No")]
        public int ContactNo { get; set; }

        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }

        [ForeignKey("Religion")]
        public int ReligionId { get; set; }

        [DisplayName("Assigned To")]
        public DateTime AssignedTo { get; set; }

        [DisplayName("Blood Group")]
        public string BloodGroup { get; set; }

        [DisplayName("Father Name")]
        public string FatherName { get; set; }

        [DisplayName("Mother Name")]
        public string MotherName { get; set; }

        [DisplayName("Home Phone No")]
        public int PhoneNo { get; set; }

        [DisplayName("Present Address")]
        public string PresentAddress { get; set; }

        [DisplayName("Permanent Address")]
        public string PermanentAddress { get; set; }

        public Designation Designation { get; set; }

        public Qualification Qualification { get; set; }

        public Religion Religion { get; set; }
    }
}
