using IssueTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IssueTracker.Data
{
    public class IssueDbContext : IdentityDbContext<IdentityUser>
	{
        public IssueDbContext(DbContextOptions<IssueDbContext> options) : base(options)
        {
        }
        public DbSet<Issue> Issues { get; set; }
    }
}
