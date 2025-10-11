using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AttendanceSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AttendanceSystem.Data;

namespace AttendanceSystem.Pages.Admin
{
    public class ViewVisitorLogsModel : PageModel
    {
        private readonly AppDbContext _context;

        public ViewVisitorLogsModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<AdminViewLog> VisitorLogs { get; set; } = new List<AdminViewLog>();

        public async Task OnGetAsync()
        {
            VisitorLogs = await _context.AdminViewLogs
                .Include(v => v.Visitors)
                .OrderByDescending(v => v.ViewedAt)
                .ToListAsync();

        }
    }
}