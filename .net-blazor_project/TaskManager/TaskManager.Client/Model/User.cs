using TaskManager.Shared.Models;

namespace TaskManager.Shared
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Relacipn con las tareas
        public List<UserTask> Tasks { get; set; } = new List<UserTask>();
    }
}
