using AttendanceSystem.Data;
using AttendanceSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace AttendanceSystem.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student? Student { get; set; } = new Student();


        public void OnGet(int id)
        {
            Student = _context.Students.FirstOrDefault(x => x.StudentId == id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            if (Student == null)
                return Page();

            _context.Students.Update(Student);
            _context.SaveChanges();

            return RedirectToPage("StudentList");
        }
    }
}
