using Microsoft.AspNetCore.Mvc;
using MovieApp.BusinessLayer;
using MovieApp.DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace MovieApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetMovieActorController : BaseController
    {
        private readonly GetMovieActorBusinessService _getMovieActorBusinessService;

        public GetMovieActorController(GetMovieActorBusinessService getMovieActorBusinessService, LinkGenerator linkGenerator)
            : base(linkGenerator)
        {
            _getMovieActorBusinessService = getMovieActorBusinessService;
        }

        // API-endpoint to get movie actors based on movieId
        [HttpGet("Actors", Name = "GetMovieActors")]
        public async Task<IActionResult> GetMovieActors(
            [FromQuery] string movieId,
            [FromQuery] int page = 0,
            [FromQuery] int pageSize = 10)
        {
            var movieActors = await _getMovieActorBusinessService.GetMovieActorsAsync(movieId);
            if (movieActors == null || movieActors.Count == 0)
            {
                return NotFound("No matching results found");
            }
            var totalItems = movieActors.Count;
            var pagedResults = movieActors.Skip(page * pageSize).Take(pageSize);

            var paginatedResponse = CreatePaging(
                "GetMovieActors",
                page,
                pageSize,
                totalItems,
                pagedResults
            );

            return Ok(paginatedResponse);
        }
    }
}
