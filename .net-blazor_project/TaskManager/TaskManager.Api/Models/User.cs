using System;
using System.Collections.Generic;

namespace TaskManager.Shared.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        public ICollection<UserTask> Tasks { get; set; } = new List<UserTask>();
    }
}
