using TaskManager.Shared.Models;

namespace TaskManager.Api.Services.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<UserTask>> GetAllAsync();
        Task<UserTask> GetByIdAsync(int id);
        Task<UserTask> CreateAsync(UserTask task);
        Task<UserTask> UpdateAsync(int id, UserTask task);
        Task<bool> DeleteAsync(int id);
    }
}
