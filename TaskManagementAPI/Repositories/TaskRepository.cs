using Microsoft.EntityFrameworkCore;
using TaskManagement.Shared;
using TaskManagementAPI.Data;
using TaskManagementAPI.Repositories;

namespace TaskManagementAPI.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly MemoryDbContext _context;

        public TaskRepository(MemoryDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskItem>> GetAllAsync(int page, int pageSize)
        {
            return await _context.Tasks
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(Guid id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task CreateAsync(TaskItem task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TaskItem task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var task = await GetByIdAsync(id);
            if (task is not null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> CountAsync()
        {
            return await _context.Tasks.CountAsync();
        }
    }
}