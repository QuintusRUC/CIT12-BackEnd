using Microsoft.EntityFrameworkCore;
using MovieApp.DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApp.DataLayer.Services
{
    public class SearchHistoryService
    {
        private readonly MovieContext _dbContext;

        public SearchHistoryService(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Get all search history
        public async Task<List<SearchHistory>> GetAllSearchHistoryAsync()
        {
            return await _dbContext.SearchHistory.ToListAsync();
        }

        // Get search history by ID
        public async Task<List<SearchHistory>> GetSearchHistoryByUserIdAsync(int userId)
        {
            // Query all search history entries matching the given userId
            return await _dbContext.SearchHistory
                .Where(history => history.UserId == userId)
                .OrderByDescending(history => history.SearchDate) // Optional: Sort by most recent search
                .ToListAsync();
        }

        // Add a search history entry
        public async Task<bool> AddSearchHistoryAsync(SearchHistory searchHistory)
        {
            _dbContext.SearchHistory.Add(searchHistory);
            return await _dbContext.SaveChangesAsync() > 0;
        }


        // Update a search history entry
        public async Task<bool> UpdateSearchHistoryAsync(SearchHistory searchHistory)
        {
            try
            {
                _dbContext.SearchHistory.Update(searchHistory);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Delete a search history entry
        public async Task<bool> DeleteSearchHistoryAsync(int searchId)
        {
            try
            {
                var entry = await _dbContext.SearchHistory.FindAsync(searchId);
                if (entry == null) return false;

                _dbContext.SearchHistory.Remove(entry);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
