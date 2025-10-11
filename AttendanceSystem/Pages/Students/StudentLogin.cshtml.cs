using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AttendanceSystem.Data;
using System.Linq;

namespace AttendanceSystem.Pages.Students
{
    public class StudentLoginModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public LoginInput Input { get; set; } = new();

        public string? ErrorMessage { get; set; }

        public StudentLoginModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var student = _context.Students.FirstOrDefault(s =>
                s.Email == Input.Email &&
                s.StudentNumber == Input.StudentNumber &&
                s.PasswordHash == Input.Password
            );

            if (student == null)
            {
                ErrorMessage = "Invalid login credentials.";
                return Page();
            }

            // ✅ Successful login
            return RedirectToPage("/Students/StudentDashboard");
        }

        public class LoginInput
        {
            public string FullName { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string StudentNumber { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }
    }
}
