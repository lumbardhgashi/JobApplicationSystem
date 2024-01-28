using System.ComponentModel.DataAnnotations;

namespace JobApplicationSystem.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Sektori { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string NumriTelefonit { get; set; }
    }
}
