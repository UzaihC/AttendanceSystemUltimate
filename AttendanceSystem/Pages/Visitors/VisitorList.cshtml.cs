using AttendanceSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AttendanceSystem.Pages.Visitors
{
    public class VisitorsListModel : PageModel
    {
        private readonly AppDbContext _context;

        public VisitorsListModel(AppDbContext context)
        {
            _context = context;
        }

        // NOTE: property name is plural "Visitors" to match the Razor foreach
        public List<AttendanceSystem.Models.Visitor> Visitors { get; set; } = new();

        public async Task OnGetAsync()
        {
            Visitors = await _context.Visitors
                //.Include(v => v.Visits) // optional if you need related visits
                .ToListAsync();
        }
    }
}