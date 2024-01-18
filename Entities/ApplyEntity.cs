﻿using System.ComponentModel.DataAnnotations;

namespace JobApplicationSystem.Models
{
    public class ApplyEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int applicantId { get; set; }
        [Required]
        public int JobPostId { get; set; }
    }
}
