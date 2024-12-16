using MovieApp.DataLayer.Models;
using MovieApp.DataLayer.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApp.BusinessLayer.Services
{
    public class SearchHistoryBusinessService
    {
        private readonly SearchHistoryService _searchHistoryService;

        public SearchHistoryBusinessService(SearchHistoryService searchHistoryService)
        {
            _searchHistoryService = searchHistoryService;
        }

        public async Task<List<SearchHistory>> GetAllSearchHistoryAsync()
        {
            return await _searchHistoryService.GetAllSearchHistoryAsync();
        }

        public async Task<List<SearchHistory>> GetSearchHistoryByUserIdAsync(int userId)
        {
            return await _searchHistoryService.GetSearchHistoryByUserIdAsync(userId);
        }

        public async Task<bool> AddSearchHistoryAsync(SearchHistory searchHistory)
        {
            return await _searchHistoryService.AddSearchHistoryAsync(searchHistory);
        }


        public async Task<bool> UpdateSearchHistoryAsync(int searchId, int userId, string searchTerm, DateTime searchDate)
        {
            var searchHistory = new SearchHistory
            {
                SearchId = searchId,
                UserId = userId,
                SearchTerm = searchTerm,
                SearchDate = searchDate
            };
            return await _searchHistoryService.UpdateSearchHistoryAsync(searchHistory);
        }

        public async Task<bool> DeleteSearchHistoryAsync(int searchId)
        {
            return await _searchHistoryService.DeleteSearchHistoryAsync(searchId);
        }
    }
}
