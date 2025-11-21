using AttendanceSystem.Data;
using AttendanceSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
namespace AttendanceSystem.Pages.Students
{ public class DeleteModel : PageModel
    { private readonly AppDbContext _context; 
        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Student? Student { get; set; } = new Student();
        public void OnGet(int StudentId)
        {
            Student = _context.Students.FirstOrDefault(x => x.StudentId == StudentId); }
        public IActionResult OnPost()
        {
            var studentToDelete = _context.Students.FirstOrDefault(x => x.StudentId == Student!.StudentId);
            if (studentToDelete != null)
            {
                _context.Students.Remove(studentToDelete);
                _context.SaveChanges();
            }
            return RedirectToPage("StudentList");
        }
    }
}