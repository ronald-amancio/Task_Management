using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using TaskManagement.Shared;

namespace TaskManagement.Pages
{
    public partial class TaskForm
    {
        [Parameter] public EventCallback<TaskItem> OnSaved { get; set; }
        
        private TaskItem TaskModel { get; set; } = new();
        private bool IsVisible { get; set; }

        public void Show(TaskItem? task = null)
        {
            TaskModel = task is not null
                ? new TaskItem
                {
                    Id = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    Status = task.Status,
                    Priority = task.Priority,
                    DueDate = task.DueDate,
                    CreatedDate = task.CreatedDate
                }
                : new TaskItem { CreatedDate = DateTime.UtcNow };

            IsVisible = true;
            StateHasChanged();
        }

        private void Close()
        {
            IsVisible = false;
            TaskModel = new();
        }

        private async Task HandleValidSubmit()
        {
            await OnSaved.InvokeAsync(TaskModel);
            Close();
        }
    }
}
