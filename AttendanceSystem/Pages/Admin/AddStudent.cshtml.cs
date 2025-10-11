using AttendanceSystem.Data;
using AttendanceSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace AttendanceSystem.Pages.Students
{
    public class AddStudentModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public StudentInput StudentForm { get; set; } = new();
        public List<AttendanceSystem.Models.Student> SavedStudents { get; set; } = new();
        public bool ShowSavedStudents { get; set; } = false;

        public AddStudentModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            if (TempData["ShowSaved"] != null)
            {
                ShowSavedStudents = true;
                LoadSavedStudents();
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var student = new AttendanceSystem.Models.Student
            {
                StudentNumber = StudentForm.StudentNumber,
                FullName = StudentForm.FullName
            };

            _context.Students.Add(student);
            _context.SaveChanges();

            TempData["Message"] = "Student added successfully!";
            TempData["ShowSaved"] = "1";

            return RedirectToPage();
        }

        private void LoadSavedStudents()
        {
            SavedStudents = _context.Students
                .OrderByDescending(s => s.StudentId)
                .Take(10)
                .ToList();
        }

        // DTO for form
        public class StudentInput
        {
            public string StudentNumber { get; set; } = string.Empty;
            public string FullName { get; set; } = string.Empty;
        }
    }
}