using System.Threading.Tasks;
using MovieApp.DataLayer.Services;
using MovieApp.DataLayer.Models;

namespace MovieApp.BusinessLayer
{
    public class MovieDetailsBusinessService
    {
        private readonly MovieDetailsService _MovieDetailsService;

        public MovieDetailsBusinessService(MovieDetailsService MovieDetailsService)
        {
            _MovieDetailsService = MovieDetailsService;
        }

        // Method to get movie details based on movieId
        public async Task<MovieDetails> MovieDetailsAsync(string movieId)
        {
            return await _MovieDetailsService.MovieDetailsAsync(movieId);
        }
    }
}
