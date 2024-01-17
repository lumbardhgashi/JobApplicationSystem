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
        public string Adresa { get; set; }
        [Required]
        public int NumriTelefonit { get; set; }
    }
}
