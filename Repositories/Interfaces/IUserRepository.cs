using SmallBizAPI.Models;
namespace SmallBizAPI.Repositories.Interfaces;
public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByIdAsync(int id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User updatedUser);
        Task Delete(User user);
}
