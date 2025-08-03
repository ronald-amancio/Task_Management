using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Shared;
using TaskManagementAPI.Data;

namespace TaskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly MemoryDbContext _context;

        public TaskController(MemoryDbContext context) => _context = context;

        #region GetTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            if (page <= 0 || pageSize <= 0)
                return BadRequest("Invalid pagination parameters.");

            var query = _context.Tasks.AsQueryable();

            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            var tasks = await query
                .OrderByDescending(t => t.CreatedDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            Response.Headers.Add("X-Total-Count", totalCount.ToString());
            Response.Headers.Add("X-Total-Pages", totalPages.ToString());

            return Ok(tasks);
        }
        #endregion

        #region GetTaskById

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(Guid id) =>
            await _context.Tasks.FindAsync(id) is TaskItem task ? Ok(task) : NotFound();
        #endregion

        #region CreateTask
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskItem task)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            task.Id = Guid.NewGuid();
            task.CreatedDate = DateTime.UtcNow;
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }
        #endregion

        #region UpdateTask
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(Guid id, TaskItem task)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != task.Id) return BadRequest();

            var existing = await _context.Tasks.FindAsync(id);
            if (existing is null) return NotFound();

            _context.Entry(existing).CurrentValues.SetValues(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #region DeleteTask
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task is null) return NotFound();

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion
    }
}