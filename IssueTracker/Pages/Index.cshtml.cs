using IssueTracker.Data;
using IssueTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace IssueTracker.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IssueDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, IssueDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGet()
        {
            Issues = await _context.Issues.Where(i => i.Completed == null)
                .OrderByDescending(i => i.Created)
                .ToListAsync();
        }

        public IEnumerable<Issue> Issues { get; set; } = Enumerable.Empty<Issue>();
    }
}