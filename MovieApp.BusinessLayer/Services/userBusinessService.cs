using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApp.DataLayer.Models;
using MovieApp.DataLayer.Services;

namespace MovieApp.BusinessLayer
{
    public class UserBusinessService
    {
        private readonly UserService _userService;

        public UserBusinessService(UserService userService)
        {
            _userService = userService;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userService.GetAllUsersAsync();
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _userService.GetUserByIdAsync(userId);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            Console.WriteLine($"DEBUG: Søger efter bruger med email: {email}");
            var user = await _userService.GetUserByEmailAsync(email);

            if (user != null)
            {
                Console.WriteLine($"DEBUG: Bruger fundet med email: {email}");
            }
            else
            {
                Console.WriteLine("DEBUG: Ingen bruger fundet.");
            }

            return user;
        }




        public async Task<bool> UpdateUserAsync(int userId, string username, string email, string password, string? role = null)
        {
            return await _userService.UpdateUserAsync(userId, username, email, password, role);
        }


        public async Task<bool> DeleteUserAsync(int userId)
        {
            return await _userService.DeleteUserAsync(userId);
        }

        public async Task<bool> AddUserViaFunctionAsync(string username, string email, string password)
        {
            return await _userService.AddUserViaFunctionAsync(username, email, password);
        }
    }
}