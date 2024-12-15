using System.Threading.Tasks;
using MovieApp.DataLayer.Services;
using MovieApp.DataLayer.Models;

namespace MovieApp.BusinessLayer
{
    public class GetMovieDetailsBusinessService
    {
        private readonly GetMovieDetailsService _getMovieDetailsService;

        public GetMovieDetailsBusinessService(GetMovieDetailsService getMovieDetailsService)
        {
            _getMovieDetailsService = getMovieDetailsService;
        }

        // Method to get movie details based on movieId
        public async Task<MovieDetails> GetMovieDetailsAsync(string movieId)
        {
            return await _getMovieDetailsService.GetMovieDetailsAsync(movieId);
        }
    }
}
