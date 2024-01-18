using System.ComponentModel.DataAnnotations;

namespace JobApplicationSystem.Entities
{
    public class JobPostingEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int HrManagerId { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public string Tittle { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Requriments { get; set; }
    }
}
