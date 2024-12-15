using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MovieApp.BusinessLayer;
using MovieApp.DataLayer.Models;

namespace MovieApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieDetailsController : ControllerBase
    {
        private readonly MovieDetailsBusinessService _MovieDetailsBusinessService;

        public MovieDetailsController(MovieDetailsBusinessService MovieDetailsBusinessService)
        {
            _MovieDetailsBusinessService = MovieDetailsBusinessService;
        }

        [HttpGet("{movieId}")]
        public async Task<ActionResult<MovieDetails>> MovieDetails(string movieId)
        {
            var movieDetails = await _MovieDetailsBusinessService.MovieDetailsAsync(movieId);
            if (movieDetails == null)
            {
                return NotFound();
            }
            return Ok(movieDetails);
        }
    }
}
