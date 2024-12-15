using System.Threading.Tasks;
using MovieApp.DataLayer.Services;
using MovieApp.DataLayer.Models;

namespace MovieApp.BusinessLayer
{
    public class ActorBusinessService
    {
        private readonly ActorService _ActorService;

        public ActorBusinessService(ActorService ActorService)
        {
            _ActorService = ActorService;
        }

        // Method to get actor details based on actorId
        public async Task<Actor> ActorAsync(string actorId)
        {
            return await _ActorService.ActorAsync(actorId);
        }

        public async Task<List<Actor>> MovieActorsAsync(string movieId)
        {
            return await _ActorService.MovieActorsAsync(movieId);
        }
    }
}
