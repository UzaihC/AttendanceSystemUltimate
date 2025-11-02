using AttendanceSystem.Data;
using AttendanceSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace AttendanceSystem.Pages.Students
{
    public class StudentsListModel : PageModel
    {
        private readonly AppDbContext _context;

        public StudentsListModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Student> Students { get; set; } = new List<Student>();

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } = string.Empty;

        public void OnGet()
        {
            var query = _context.Students.AsQueryable();

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                query = query.Where(s => s.FullName.Contains(SearchTerm) || s.StudentNumber.Contains(SearchTerm));
            }

            Students = query.ToList();
        }
    }

}
