using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Shared
{
    public enum TaskStatus { Todo, InProgress, Done }
    public enum TaskPriority { Low, Medium, High }

    public class TaskItem
    {
        public Guid Id { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        
        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        [EnumDataType(typeof(TaskStatus))]
        public TaskStatus Status { get; set; }

        [Required]
        [EnumDataType(typeof(TaskPriority))]
        public TaskPriority Priority { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DueDate { get; set; }
    }
}