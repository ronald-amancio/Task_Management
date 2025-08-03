using Microsoft.EntityFrameworkCore;
using TaskManagement.Shared;

namespace TaskManagementAPI.Data
{
    public class MemoryDbContext : DbContext
    {
        public MemoryDbContext(DbContextOptions options) : base(options) { }
        public DbSet<TaskItem> Tasks => Set<TaskItem>();
    }
}