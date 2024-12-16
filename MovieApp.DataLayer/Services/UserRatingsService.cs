using Microsoft.EntityFrameworkCore;
using MovieApp.DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApp.DataLayer.Services
{
    public class UserRatingService
    {
        private readonly MovieContext _dbContext;

        public UserRatingService(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserRating>> GetAllRatingsAsync()
        {
            return await _dbContext.UserRatings.ToListAsync();
        }

        public async Task<UserRating> GetRatingByIdAsync(int ratingId)
        {
            return await _dbContext.UserRatings.FindAsync(ratingId);
        }

        public async Task<bool> AddRatingAsync(UserRating rating)
        {
            try
            {
                await _dbContext.UserRatings.AddAsync(rating);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateRatingAsync(UserRating rating)
        {
            try
            {
                _dbContext.UserRatings.Update(rating);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteRatingAsync(int ratingId)
        {
            try
            {
                var rating = await _dbContext.UserRatings.FindAsync(ratingId);
                if (rating == null) return false;
                _dbContext.UserRatings.Remove(rating);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<UserRating>> GetRatingsByUserIdAsync(int userId)
        {
            var query = $"SELECT * FROM user_ratings WHERE user_id = {userId}";
            return await _dbContext.UserRatings.FromSqlRaw(query).ToListAsync();
        }
    }
}
