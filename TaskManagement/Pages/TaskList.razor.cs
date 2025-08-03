using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using TaskManagement.Services;
using TaskManagement.Shared;

namespace TaskManagement.Pages
{
    public partial class TaskList : ComponentBase
    {
        [Inject] private TaskService TaskService { get; set; }
        [Inject] private NotificationService NotificationService { get; set; } = default!;


        private TaskForm? taskForm;
        private ConfirmDialog? confirmDialog;

        private List<TaskItem> tasks = new();
        private int pages = 1;
        private int pageSize = 5;
        private int totalCount = 0;
        private int totalPages => (int)Math.Ceiling(totalCount / (double)pageSize);

        protected override async Task OnInitializedAsync()
        {
            await LoadTasks();
        }

        private async Task LoadTasks()
        {
            var result = await TaskService.GetTasksAsync(pages, pageSize);
            tasks = result.Tasks;
            totalCount = result.TotalCount;
        }

        private async Task NextPage()
        {
            if (pages < totalPages)
            {
                pages++;
                await LoadTasks();
            }
        }

        private async Task PrevPage()
        {
            if (pages > 1)
            {
                pages--;
                await LoadTasks();
            }
        }

        private string GetPriorityClass(TaskPriority p) => p switch
        {
            TaskPriority.High => "danger",
            TaskPriority.Medium => "warning",
            _ => "success"
        };

        private void ShowAddForm()
        {
            taskForm?.Show();
        }

        private void Edit(TaskItem task)
        {
            taskForm?.Show(task);
        }

        private async Task Delete(Guid id)
        {
            if (confirmDialog != null)
            {
                bool confirmed = await confirmDialog.Show("Delete Task", "Are you sure you want to delete this task?");
                if (confirmed)
                {
                    await TaskService.DeleteTask(id);
                    await LoadTasks();
                    NotificationService.ShowSuccess("Task deleted successfully!");
                }
            }
        }

        private async Task OnTaskSaved(TaskItem saved)
        {
            if (saved.Id == Guid.Empty)
            {
                saved.Id = Guid.NewGuid();
                await TaskService.CreateTask(saved);
                NotificationService.ShowSuccess("Task created successfully!");
            }
            else
            {
                await TaskService.UpdateTask(saved.Id, saved);
                NotificationService.ShowSuccess("Task updated successfully!");
            }

            await LoadTasks();
        }
    }
}
