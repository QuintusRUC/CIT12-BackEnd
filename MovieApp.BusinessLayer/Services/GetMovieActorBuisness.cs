using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApp.DataLayer.Services;
using MovieApp.DataLayer.Models;

namespace MovieApp.BusinessLayer
{
    public class GetMovieActorBusinessService
    {
        private readonly GetMovieActorService _getMovieActorService;

        public GetMovieActorBusinessService(GetMovieActorService getMovieActorService)
        {
            _getMovieActorService = getMovieActorService;
        }

        // Method to get movie actors based on movieId
        public async Task<List<MovieActorResult>> GetMovieActorsAsync(string movieId)
        {
            return await _getMovieActorService.GetMovieActorsAsync(movieId);
        }
    }
}
