using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MovieApp.BusinessLayer;
using MovieApp.DataLayer.Models;
using WebApi.Controllers;

namespace MovieApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorController : BaseController
    {
        private readonly ActorBusinessService _ActorBusinessService;

        public ActorController(ActorBusinessService ActorBusinessService, LinkGenerator linkGenerator): base(linkGenerator)
        {
            _ActorBusinessService = ActorBusinessService;
        }

        [HttpGet("{actorId}")]
        public async Task<ActionResult<Actor>> Actor(string actorId)
        {
            var actor = await _ActorBusinessService.ActorAsync(actorId);
            if (actor == null)
            {
                return NotFound();
            }
            return Ok(actor);
        }

        [HttpGet("movie/{movieId}", Name = "MovieActors")]
        public async Task<ActionResult<List<Actor>>> MovieActors(string movieId,
            [FromQuery] int page = 0,
            [FromQuery] int pageSize = 10)
        {
            var actors = await _ActorBusinessService.MovieActorsAsync(movieId);
            if (actors == null || actors.Count == 0)
            {
                return NotFound("No actors found for the given movie.");
            }
            var totalItems = actors.Count;
            var pagedResults = actors.Skip(page * pageSize).Take(pageSize);

            var paginatedResponse = CreatePaging(
                "MovieActors",
                page,
                pageSize,
                totalItems,
                pagedResults
            );

            return Ok(paginatedResponse);
        }
    }
}