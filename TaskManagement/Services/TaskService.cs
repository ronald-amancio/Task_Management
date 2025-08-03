using TaskManagement.Models.ViewModel;
using TaskManagement.Shared;

namespace TaskManagement.Services
{
    public class TaskService
    {
        private readonly HttpClient _http;
        private readonly LoadingService _loading;
        public TaskService(HttpClient http, LoadingService loading)
        {
            _http = http;
            _loading = loading;
        }

        public async Task<PagedTaskResult> GetTasksAsync(int page = 1, int pageSize = 10)
        {
            try
            {
                _loading.Show();
                var response = await _http.GetAsync($"api/Task?page={page}&pageSize={pageSize}");
                response.EnsureSuccessStatusCode();

                var tasks = await response.Content.ReadFromJsonAsync<List<TaskItem>>() ?? new();

                int totalCount = 0;
                if (response.Headers.TryGetValues("X-Total-Count", out var countValues))
                {
                    int.TryParse(countValues.FirstOrDefault(), out totalCount);
                }

                return new PagedTaskResult
                {
                    Tasks = tasks,
                    TotalCount = totalCount
                };
            }
            finally {
                _loading.Hide();
            }
        }

        public async Task<TaskItem?> GetTaskById(Guid id)
        {
            try
            {
                _loading.Show();
                return await _http.GetFromJsonAsync<TaskItem>($"api/Task/{id}");
            }
            finally
            {
                _loading.Hide();
            }
        }

        public async Task CreateTask(TaskItem task)
        {
            try
            {
                _loading.Show();
                await _http.PostAsJsonAsync("api/Task", task);
            }
            finally
            {
                _loading.Hide();
            }
        }

        public async Task UpdateTask(Guid id, TaskItem task)
        {
            try
            {
                _loading.Show();
                await _http.PutAsJsonAsync($"api/Task/{id}", task);
            }
            finally
            {
                _loading.Hide();
            }
        }

        public async Task DeleteTask(Guid id)
        {
            try
            {
                _loading.Show();
                await _http.DeleteAsync($"api/Task/{id}");
            }
            finally
            {
                _loading.Hide();
            }
        }
    }
}