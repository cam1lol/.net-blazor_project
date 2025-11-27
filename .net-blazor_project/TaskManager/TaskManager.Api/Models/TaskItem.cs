using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Api.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        // Fecha de creación
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Fecha de vencimiento
        public DateTime DueDate { get; set; }

        // Relación con User
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
