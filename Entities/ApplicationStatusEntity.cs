using System.ComponentModel.DataAnnotations;

namespace JobApplicationSystem.Entities
{
    public class ApplicationStatusEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ReviewApplicationId { get; set; }
        [Required]
        public string Status { get; set; }
        public string StatusDescription { get; set; }
    }
}
