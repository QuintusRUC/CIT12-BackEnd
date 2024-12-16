using MovieApp.DataLayer.Models;
using MovieApp.DataLayer.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApp.BusinessLayer.Services
{
    public class UserRatingBusinessService
    {
        private readonly UserRatingService _userRatingService;

        public UserRatingBusinessService(UserRatingService userRatingService)
        {
            _userRatingService = userRatingService;
        }

        public async Task<List<UserRating>> GetAllRatingsAsync()
        {
            return await _userRatingService.GetAllRatingsAsync();
        }

        public async Task<UserRating> GetRatingByIdAsync(int ratingId)
        {
            return await _userRatingService.GetRatingByIdAsync(ratingId);
        }

        public async Task<bool> AddRatingAsync(int userId, string tconst, decimal rating)
        {
            var newRating = new UserRating
            {
                UserId = userId,
                Tconst = tconst,
                Rating = rating
            };
            return await _userRatingService.AddRatingAsync(newRating);
        }

        public async Task<bool> UpdateRatingAsync(int ratingId, int userId, string tconst, decimal rating)
        {
            var updatedRating = new UserRating
            {
                RatingId = ratingId,
                UserId = userId,
                Tconst = tconst,
                Rating = rating
            };
            return await _userRatingService.UpdateRatingAsync(updatedRating);
        }

        public async Task<bool> DeleteRatingAsync(int ratingId)
        {
            return await _userRatingService.DeleteRatingAsync(ratingId);
        }

        public async Task<List<UserRating>> GetRatingsByUserIdAsync(int userId)
        {
            return await _userRatingService.GetRatingsByUserIdAsync(userId);
        }
    }
}
