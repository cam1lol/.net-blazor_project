namespace TaskManager.Shared.Models
{
    public class UserTask
    {
        public int TaskId { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Status { get; set; }
    }
}
