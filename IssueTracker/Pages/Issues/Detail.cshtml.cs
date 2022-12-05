using IssueTracker.Data;
using IssueTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IssueTracker.Pages.Issues
{
    public class DetailModel : PageModel
    {
        private readonly IssueDbContext _context;
        public DetailModel(IssueDbContext context) => _context = context;

        public async Task OnGet(int id)
        {
            Issue = await _context.Issues.FindAsync(id);
        }
        public Issue Issue { get; set; }
    }
}
