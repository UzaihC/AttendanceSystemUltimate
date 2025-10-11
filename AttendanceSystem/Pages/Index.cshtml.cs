using AttendanceSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AttendanceSystem.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        public List<AttendanceSystem.Models.Student> Students { get; set; } = new();
        public string? ErrorMessage { get; set; }

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            try
            {
                Students = _context.Students.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                Students = new List<AttendanceSystem.Models.Student>();
                ErrorMessage = "Database error: " + ex.Message;
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // save logic here
            TempData["Message"] = "Attendance saved successfully!";
            return RedirectToPage();
        }

    }
}