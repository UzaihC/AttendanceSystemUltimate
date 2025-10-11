using AttendanceSystem.Data;
using AttendanceSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace AttendanceSystem.Pages.Students
{
    public class StudentRegisterModel : PageModel
    {
        private readonly AppDbContext _context;

        public StudentRegisterModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RegisterInput Input { get; set; } = new();

        public string? Message { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Message = "⚠️ Please fill all fields correctly.";
                return Page();
            }

            // Check if already registered
            var exists = _context.Students.Any(s => s.Email == Input.Email || s.StudentNumber == Input.StudentNumber);
            if (exists)
            {
                Message = "⚠️ Student already registered!";
                return Page();
            }

            // Save new student
            var student = new Student
            {
                Email = Input.Email,
                StudentNumber = Input.StudentNumber,
                PasswordHash = Input.Password,
                FullName = Input.FullName
            };

            _context.Students.Add(student);
            _context.SaveChanges();

            Message = "✅ Registration successful!";
            ModelState.Clear();
            Input = new RegisterInput(); // clear form
            return Page();
        }

        public class RegisterInput
        {
            public string Email { get; set; } = string.Empty;
            public string StudentNumber { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
            public string FullName { get; set; } = string.Empty;
        }
    }
}