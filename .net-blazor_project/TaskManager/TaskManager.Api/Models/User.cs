using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Api.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        // Relación uno a muchos
        public ICollection<TaskItem> Tasks { get; set; }
    }
}
