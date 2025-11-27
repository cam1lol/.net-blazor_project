using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Data;
using TaskManager.Shared.Models;
using TaskManager.Api.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskManager.Api.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        // Obtener todas las tareas con su usuario asociado
        public async Task<IEnumerable<UserTask>> GetAllAsync()
        {
            return await _context.UserTasks
                                 .Include(t => t.User)
                                 .ToListAsync();
        }

        // Obtener una tarea por ID (nullable)
        public async Task<UserTask?> GetByIdAsync(int id)
        {
            return await _context.UserTasks
                                 .Include(t => t.User)
                                 .FirstOrDefaultAsync(t => t.TaskId == id);
        }

        // Crear una nueva tarea
        public async Task<UserTask> CreateAsync(UserTask task)
        {
            _context.UserTasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        // Actualizar una tarea existente
        public async Task<UserTask?> UpdateAsync(int id, UserTask task)
        {
            var existingTask = await _context.UserTasks.FindAsync(id);
            if (existingTask == null) return null;

            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.UserId = task.UserId;
            existingTask.DueDate = task.DueDate;
            existingTask.Status = task.Status;
            existingTask.UpdatedAt = System.DateTime.Now;

            await _context.SaveChangesAsync();
            return existingTask;
        }

        // Eliminar una tarea por ID
        public async Task<bool> DeleteAsync(int id)
        {
            var task = await _context.UserTasks.FindAsync(id);
            if (task == null) return false;

            _context.UserTasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
