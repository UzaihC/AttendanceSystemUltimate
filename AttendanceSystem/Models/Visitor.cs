using System;
using System.ComponentModel.DataAnnotations;

namespace AttendanceSystem.Models
{
    public class Visitor
    {
        [Key]
        public int VisitorId { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public DateTime VisitDate { get; set; } = DateTime.Now;

        [Required]
        [StringLength(100)]
        public string Office { get; set; } = string.Empty;
        // e.g., "Registrar’s Office", "Guidance Office", "Office of Student Affairs"

        [Required]
        [StringLength(255)]
        public string Purpose { get; set; } = string.Empty;


    }
}