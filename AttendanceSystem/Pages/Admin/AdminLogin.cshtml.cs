using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AttendanceSystem.Pages.Admin
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public AdminLogin Input { get; set; } = new();

        public string? ErrorMessage { get; set; }

        public IActionResult OnPost()
        {
            if (Input.Username == "admin" && Input.Password == "1234")
            {
                return RedirectToPage("/Admin/AdminDashboard");
            }

            ErrorMessage = "Invalid admin credentials!";
            return Page();
        }

        public class AdminLogin
        {
            public string Username { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }
    }
}