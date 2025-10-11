using AttendanceSystem.Data;
using AttendanceSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AttendanceSystem.Pages.Visitors
{
    public class AddVisitorModel : PageModel
    {
        private readonly AppDbContext _context;

        public AddVisitorModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Visitor Visitor { get; set; }

        public void OnGet()
        {
            // Set default visit date to today
            Visitor = new Visitor
            {
                VisitDate = DateTime.Now
            };
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // return form with validation errors
            }

            _context.Visitors.Add(Visitor);
            _context.SaveChanges();

            // ✅ Redirect to Visitor Logs page after submission
            return RedirectToPage("/Visitors/ViewVisitorLogs");
        }
    }
}