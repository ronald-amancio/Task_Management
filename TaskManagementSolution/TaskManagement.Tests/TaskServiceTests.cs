using Moq;
using TaskManagement.Shared;
using TaskManagementAPI.Repositories;
using TaskManagementAPI.Services;

namespace TaskManagement.Tests
{
    public class TaskServiceTests
    {
        [Fact]
        public async Task AddTask_CallsRepository()
        {
            // Arrange
            var mockRepo = new Mock<ITaskRepository>();
            var service = new TaskService(mockRepo.Object);

            var task = new TaskItem
            {
                Title = "Mocked Task",
                CreatedDate = DateTime.UtcNow,
                Priority = TaskPriority.Medium,
                Status = TaskManagement.Shared.TaskStatus.Todo
            };

            // Act
            await service.CreateTask(task);

            // Assert
            mockRepo.Verify(r => r.CreateAsync(It.Is<TaskItem>(t => t.Title == "Mocked Task")), Times.Once);
        }
    }
}