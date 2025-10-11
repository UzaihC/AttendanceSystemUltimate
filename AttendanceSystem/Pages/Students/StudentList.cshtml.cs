using AttendanceSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AttendanceSystem.Pages.Students
{
    public class StudentsListModel : PageModel
    {
        private readonly AppDbContext _context;

        public StudentsListModel(AppDbContext context)
        {
            _context = context;
        }

        public List<AttendanceSystem.Models.Student> Students { get; set; } = new();

        public async Task OnGetAsync()
        {
            Students = await _context.Students.ToListAsync();
        }
    }
}