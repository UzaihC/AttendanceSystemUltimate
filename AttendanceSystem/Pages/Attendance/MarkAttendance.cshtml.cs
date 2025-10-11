using AttendanceSystem.Data;
using AttendanceSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace AttendanceSystem.Pages.Attendance
{
    public class MarkAttendanceModel : PageModel
    {
        private readonly AppDbContext _context;

        public MarkAttendanceModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<AttendanceSystem.Models.Student> Students { get; set; } = new();

        [BindProperty]
        public StudentInput NewStudent { get; set; } = new();

        [BindProperty]
        public Dictionary<int, string> AttendanceStatuses { get; set; } = new();

        public string Message { get; set; } = string.Empty;

        public void OnGet()
        {
            LoadStudents();
        }

        public IActionResult OnPostAddStudent()
        {
            if (!ModelState.IsValid)
            {
                LoadStudents();
                return Page();
            }

            var exists = _context.Students.Any(s => s.StudentNumber == NewStudent.StudentNumber);
            if (exists)
            {
                Message = "Student already exists!";
            }
            else
            {
                var student = new AttendanceSystem.Models.Student
                {
                    StudentNumber = NewStudent.StudentNumber,
                    FullName = NewStudent.FullName
                };
                _context.Students.Add(student);
                _context.SaveChanges();
                Message = "Student added successfully!";
            }

            LoadStudents();
            return Page();
        }

        public IActionResult OnPostSaveAttendance()
        {
            foreach (var item in AttendanceStatuses)
            {
                var studentId = item.Key;
                var status = item.Value;

                var attendance = new AttendanceRecord
                {
                    StudentId = studentId,
                    Status = status,
                    Date = DateTime.Now
                };
                _context.AttendanceRecords.Add(attendance);
            }

            _context.SaveChanges();
            Message = "Attendance saved successfully!";
            LoadStudents();
            return Page();
        }

        private void LoadStudents()
        {
            Students = _context.Students.OrderBy(s => s.FullName).ToList();
        }

        public class StudentInput
        {
            public string StudentNumber { get; set; } = string.Empty;
            public string FullName { get; set; } = string.Empty;
        }
    }
}