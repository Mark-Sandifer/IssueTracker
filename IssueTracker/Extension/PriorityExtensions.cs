using IssueTracker.Models;

namespace IssueTracker.Extension
{
    public static class PriorityExtensions
    {
        static readonly Dictionary<Priority, string> _priorityCssClasses = new()
        {
            [Priority.High] = "badge bg-danger",
            [Priority.Medium] = "badge bg-warning text-dark",
            [Priority.Low] = "badge bg-success"
        };
        public static string ToCssClass(this Priority priority)
        {
            return _priorityCssClasses[priority];
        }
    }
}
