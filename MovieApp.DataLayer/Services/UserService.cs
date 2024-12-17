using Microsoft.EntityFrameworkCore;
using MovieApp.DataLayer.Models;
using BCrypt.Net; // Importér BCrypt
namespace MovieApp.DataLayer.Services
{
    public class UserService
    {
        private readonly MovieContext _dbContext;

        public UserService(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Hent alle brugere
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _dbContext.users.ToListAsync();
        }

        // Hent bruger efter ID
        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _dbContext.users.FindAsync(userId);
        }

        // Tilføj bruger


        // Opdater bruger
        public async Task<bool> UpdateUserAsync(int userId, string username, string email, string password, string? role = null)
        {
            try
            {
                await _dbContext.Database.ExecuteSqlRawAsync(
                    "UPDATE users SET username = {0}, email = {1}, password = {2}, role = {3} WHERE user_id = {4}",
                    username, email, password, role, userId
                );
                return true;
            }
            catch
            {
                return false;
            }
        }


        // Slet bruger
        public async Task<bool> DeleteUserAsync(int userId)
        {
            try
            {
                var user = await _dbContext.users.FindAsync(userId);
                if (user == null) return false;

                _dbContext.users.Remove(user);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Tilføj bruger via databasefunktion


        public async Task<bool> AddUserViaFunctionAsync(string username, string email, string password)
        {
            try
            {
                // Hash password med salt
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                // Debugging: Vis det hash'ede password
                Console.WriteLine($"DEBUG: Opretter bruger med email: {email}");
                Console.WriteLine($"DEBUG: Hash'et password: {hashedPassword}");

                // Gem det hash'ede password i databasen
                await _dbContext.Database.ExecuteSqlRawAsync(
                    "SELECT add_user({0}, {1}, {2})",
                    username, email, hashedPassword
                );

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DEBUG: Fejl under oprettelse af bruger: {ex.Message}");
                return false;
            }
        }


        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _dbContext.users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

    }
}