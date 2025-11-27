using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Shared.Models
{
    public class UserTask
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public string Status { get; set; } = "Pendiente";

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // <<< Propiedad de navegación
        public User User { get; set; }
    }
}
