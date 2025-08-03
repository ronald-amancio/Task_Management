using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Shared;

namespace TaskManagement.Tests
{
    public class TaskItemValidationTests
    {
        [Fact]
        public void Title_IsRequired()
        {
            var task = new TaskItem { Title = "", CreatedDate = DateTime.UtcNow };
            var context = new ValidationContext(task);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(task, context, results, true);

            Assert.False(isValid);
            Assert.Contains(results, r => r.MemberNames.Contains(nameof(TaskItem.Title)));
        }
    }
}