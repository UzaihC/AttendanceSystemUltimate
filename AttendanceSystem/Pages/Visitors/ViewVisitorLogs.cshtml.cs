using Microsoft.AspNetCore.Mvc.RazorPages;
using AttendanceSystem.Data;
using AttendanceSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace AttendanceSystem.Pages.Visitors
{
    public class ViewVisitorLogsModel : PageModel
    {
        private readonly AppDbContext _context;

        public ViewVisitorLogsModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Visitor> Visitors { get; set; }

        public void OnGet()
        {
            // Retrieve all visitors from the database
            Visitors = _context.Visitors.ToList();
        }
    }
}
