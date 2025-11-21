using AttendanceSystem.Data;
using AttendanceSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AttendanceSystem.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; } = new Student();

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Students.Add(Student);
            _context.SaveChanges();

            return RedirectToPage("StudentList");
        }
    }
}
