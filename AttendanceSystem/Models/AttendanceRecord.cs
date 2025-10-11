using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceSystem.Models
{
    public class AttendanceRecord
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty; // ✅ Present / Absent

        public DateTime Date { get; set; } = DateTime.Now;

        public Student? Student { get; set; }
    }
}