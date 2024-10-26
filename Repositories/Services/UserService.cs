using Microsoft.EntityFrameworkCore;
using SmallBizAPI.Data;
using SmallBizAPI.Models;
using SmallBizAPI.Repositories.Interfaces;

namespace SmallBizAPI.Repositories.Services
{
    public class UserService : BaseService, IUserRepository
    {
        public UserService(SmallBizDBContext context) : base(context)
        {
        }

        public async Task CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }


        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateUserAsync(User updatedUser)
        {
            var existingUser = await _context.Users.FindAsync(updatedUser.Id);
            existingUser.FirstName = updatedUser.FirstName;
            existingUser.LastName = updatedUser.LastName;
            existingUser.Email = updatedUser.Email;
            await _context.SaveChangesAsync();
        }

    }

    
}