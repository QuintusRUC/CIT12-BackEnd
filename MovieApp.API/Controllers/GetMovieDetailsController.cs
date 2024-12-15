using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MovieApp.BusinessLayer;
using MovieApp.DataLayer.Models;

namespace MovieApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetMovieDetailsController : ControllerBase
    {
        private readonly GetMovieDetailsBusinessService _getMovieDetailsBusinessService;

        public GetMovieDetailsController(GetMovieDetailsBusinessService getMovieDetailsBusinessService)
        {
            _getMovieDetailsBusinessService = getMovieDetailsBusinessService;
        }

        [HttpGet("{movieId}")]
        public async Task<ActionResult<MovieDetails>> GetMovieDetails(string movieId)
        {
            var movieDetails = await _getMovieDetailsBusinessService.GetMovieDetailsAsync(movieId);
            if (movieDetails == null)
            {
                return NotFound();
            }
            return Ok(movieDetails);
        }
    }
}
