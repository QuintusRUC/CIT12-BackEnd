using Microsoft.AspNetCore.Mvc;
using MovieApp.BusinessLayer.Services;
using System.Threading.Tasks;

namespace MovieApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRatingController : ControllerBase
    {
        private readonly UserRatingBusinessService _userRatingBusinessService;

        public UserRatingController(UserRatingBusinessService userRatingBusinessService)
        {
            _userRatingBusinessService = userRatingBusinessService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRatings()
        {
            var ratings = await _userRatingBusinessService.GetAllRatingsAsync();
            return Ok(ratings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRatingById(int id)
        {
            var rating = await _userRatingBusinessService.GetRatingByIdAsync(id);
            if (rating == null)
                return NotFound("Rating not found");
            return Ok(rating);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddRating(int userId, string tconst, decimal rating)
        {
            var success = await _userRatingBusinessService.AddRatingAsync(userId, tconst, rating);
            if (success)
                return Ok("Rating added successfully.");
            return StatusCode(500, "Failed to add rating.");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateRating(int ratingId, int userId, string tconst, decimal rating)
        {
            var success = await _userRatingBusinessService.UpdateRatingAsync(ratingId, userId, tconst, rating);
            if (success)
                return Ok("Rating updated successfully.");
            return StatusCode(500, "Failed to update rating.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRating(int id)
        {
            var success = await _userRatingBusinessService.DeleteRatingAsync(id);
            if (success)
                return Ok("Rating deleted successfully.");
            return StatusCode(500, "Failed to delete rating.");
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetRatingByUserId(int userId)
        {
            var ratings = await _userRatingBusinessService.GetRatingsByUserIdAsync(userId);
            return Ok(ratings);
        }
    }
}
