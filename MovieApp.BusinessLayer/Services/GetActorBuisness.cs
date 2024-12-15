using System.Threading.Tasks;
using MovieApp.DataLayer.Services;
using MovieApp.DataLayer.Models;

namespace MovieApp.BusinessLayer
{
    public class GetActorBusinessService
    {
        private readonly GetActorService _getActorService;

        public GetActorBusinessService(GetActorService getActorService)
        {
            _getActorService = getActorService;
        }

        // Method to get actor details based on actorId
        public async Task<Actor> GetActorAsync(string actorId)
        {
            return await _getActorService.GetActorAsync(actorId);
        }
    }
}
