using TaskManagement.Shared;

namespace TaskManagement.Models.ViewModel
{
    public class PagedTaskResult
    {
        public List<TaskItem> Tasks { get; set; } = new();
        public int TotalCount { get; set; }
    }
}