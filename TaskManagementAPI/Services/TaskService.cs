using TaskManagement.Shared;
using TaskManagementAPI.Repositories;

namespace TaskManagementAPI.Services
{
    public class TaskService
    {
        private readonly ITaskRepository _repo;

        public TaskService(ITaskRepository repo)
        {
            _repo = repo;
        }

        public Task<List<TaskItem>> GetAllTasks(int page, int pageSize) =>
            _repo.GetAllAsync(page, pageSize);

        public Task<TaskItem?> GetTaskById(Guid id) =>
            _repo.GetByIdAsync(id);

        public Task CreateTask(TaskItem task) =>
            _repo.CreateAsync(task);

        public Task UpdateTask(TaskItem task) =>
            _repo.UpdateAsync(task);

        public Task DeleteTask(Guid id) =>
            _repo.DeleteAsync(id);

        public Task<int> GetTotalCount() =>
            _repo.CountAsync();
    }
}