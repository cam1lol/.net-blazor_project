using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Data;
using TaskManager.Shared.Models;
using TaskManager.Api.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskManager.Api.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        // Obtener todos los usuarios con sus tareas
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users
                                 .Include(u => u.Tasks)
                                 .ToListAsync();
        }

        // Obtener un usuario por ID (nullable)
        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users
                                 .Include(u => u.Tasks)
                                 .FirstOrDefaultAsync(u => u.UserId == id);
        }

        // Crear un nuevo usuario
        public async Task<User> CreateAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        // Actualizar un usuario existente
        public async Task<User?> UpdateAsync(int id, User user)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null) return null;

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.UpdatedAt = System.DateTime.Now;

            await _context.SaveChangesAsync();
            return existingUser;
        }

        // Eliminar un usuario por ID
        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
