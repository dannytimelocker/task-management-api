using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private static List<TaskItem> tasks = new List<TaskItem>();
        private static int nextId = 1;

        // GET: api/tasks
        [HttpGet]
        public IActionResult GetTasks()
        {
            return Ok(tasks);
        }

        // POST: api/tasks
        [HttpPost]
        public IActionResult CreateTask(TaskItem task)
        {
            task.Id = nextId++;
            tasks.Add(task);
            return Ok(task);
        }

        // PUT: api/tasks/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, TaskItem updatedTask)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return NotFound();

            task.Title = updatedTask.Title;
            task.IsDone = updatedTask.IsDone;

            return Ok(task);
        }

        // DELETE: api/tasks/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return NotFound();

            tasks.Remove(task);
            return Ok();
        }
    }
}