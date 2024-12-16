using Microsoft.AspNetCore.Mvc;
using MovieApp.BusinessLayer.Services;
using MovieApp.DataLayer.Models;
using System.Threading.Tasks;
using System;

namespace MovieApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchHistoryController : ControllerBase
    {
        private readonly SearchHistoryBusinessService _searchHistoryBusinessService;

        public SearchHistoryController(SearchHistoryBusinessService searchHistoryBusinessService)
        {
            _searchHistoryBusinessService = searchHistoryBusinessService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSearchHistory()
        {
            var history = await _searchHistoryBusinessService.GetAllSearchHistoryAsync();
            if (history == null || history.Count == 0)
                return NotFound("No search history entries found.");
            return Ok(history);
        }

        [HttpGet("User/{userId}")]
        public async Task<IActionResult> GetSearchHistoryByUserId(int userId)
        {
            // Fetch all search history entries for the provided userId
            var history = await _searchHistoryBusinessService.GetSearchHistoryByUserIdAsync(userId);
            // If no entries are found, return a 404 response
            if (history == null || history.Count == 0)
            {
                return NotFound($"No search history found for user with ID {userId}.");
            }
            // Return the list of search history entries
            return Ok(history);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddSearchHistory(int userId, string searchTerm, DateTime? searchDate = null)
        {
            var utcDate = (searchDate ?? DateTime.Now).ToUniversalTime(); // Default to current UTC time if not provided
            var entry = new SearchHistory
            {
                UserId = userId,
                SearchTerm = searchTerm,
                SearchDate = utcDate
            };

            var success = await _searchHistoryBusinessService.AddSearchHistoryAsync(entry);
            if (success)
                return Ok("Search history entry added successfully.");
            return StatusCode(500, "Failed to add search history entry.");
        }



        [HttpPut("Update")]
        public async Task<IActionResult> UpdateSearchHistory(int searchId, int userId, string searchTerm, DateTime searchDate)
        {
            var success = await _searchHistoryBusinessService.UpdateSearchHistoryAsync(searchId, userId, searchTerm, searchDate);
            if (success)
                return Ok("Search history entry updated successfully.");
            return StatusCode(500, "Failed to update search history entry.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSearchHistory(int id)
        {
            var success = await _searchHistoryBusinessService.DeleteSearchHistoryAsync(id);
            if (success)
                return Ok("Search history entry deleted successfully.");
            return StatusCode(500, "Failed to delete search history entry.");
        }
    }
}
