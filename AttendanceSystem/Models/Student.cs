namespace AttendanceSystem.Models
{
    public class Student
    {
        public int? StudentId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string StudentNumber { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}