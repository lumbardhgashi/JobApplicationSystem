using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobApplicationSystem.Entities
{
    public class JobPostingEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("HrManager")]
        public int HrManagerId { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        [Required]
        public string Tittle { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Requriments { get; set; }
        public ICollection<ApplyEntity> Applies { get; set; }
        public DepartmentEntity Department { get; set; }
        public HRManagerEntity HrManager { get; set; }
    }
}
