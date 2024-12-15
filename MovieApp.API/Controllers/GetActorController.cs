using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MovieApp.BusinessLayer;
using MovieApp.DataLayer.Models;

namespace MovieApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetActorController : ControllerBase
    {
        private readonly GetActorBusinessService _getActorBusinessService;

        public GetActorController(GetActorBusinessService getActorBusinessService)
        {
            _getActorBusinessService = getActorBusinessService;
        }

        [HttpGet("{actorId}")]
        public async Task<ActionResult<Actor>> GetActor(string actorId)
        {
            var actor = await _getActorBusinessService.GetActorAsync(actorId);
            if (actor == null)
            {
                return NotFound();
            }
            return Ok(actor);
        }
    }
}
