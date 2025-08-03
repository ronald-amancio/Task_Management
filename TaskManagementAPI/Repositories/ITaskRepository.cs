using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Shared;

namespace TaskManagementAPI.Repositories
{
    public interface ITaskRepository
    {
        Task<List<TaskItem>> GetAllAsync(int page, int pageSize);
        Task<TaskItem?> GetByIdAsync(Guid id);
        Task CreateAsync(TaskItem task);
        Task UpdateAsync(TaskItem task);
        Task DeleteAsync(Guid id);
        Task<int> CountAsync();
    }
}