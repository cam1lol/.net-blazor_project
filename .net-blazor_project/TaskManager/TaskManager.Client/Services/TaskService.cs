using TaskManager.Shared.Models;

namespace TaskManager.Client.Services
{
    public class TaskService
    {
        private List<UserTask> tasks = new()
        {
            new UserTask { TaskId = 1, Title = "Tarea 1", Description = "Descripción 1", Status = "Pending" },
            new UserTask { TaskId = 2, Title = "Tarea 2", Description = "Descripción 2", Status = "Done" }
        };

        public Task<List<UserTask>> GetTasksAsync() => Task.FromResult(tasks);
    }
}
