using TaskManager.Shared.Models;

namespace TaskManager.Client.Services
{
    public class UserService
    {
        private List<User> users = new()
        {
            new User { UserId = 1, Name = "Camilo", Email = "camilo@email.com" },
            new User { UserId = 2, Name = "Ana", Email = "ana@email.com" }
        };

        public Task<List<User>> GetUsersAsync() => Task.FromResult(users);
    }
}
