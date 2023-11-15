using HW4.Models;
using HW4.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HW4.Controllers
{
    [Route("api/movie")]
    [ApiController]
    public class MovieApiController : ControllerBase
    {
        private readonly IShowService _showService;
        private readonly ILogger<MovieApiController> _logger;

        public MovieApiController(IShowService showService, ILogger<MovieApiController> logger)
        {
            _showService = showService;
            _logger = logger;
        }

        // GET: api/movie/search?title=____
        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MovieInfo>>> SearchMoviesByTitleAsync([FromQuery][Required] string title)
        {
            IEnumerable<MovieInfo> movies;
            try
            {
                movies = await _showService.SearchMoviesByTitleAsync(title);
                // uncomment to manually test the error handling in the JS
                //throw new Exception();
            }
            catch (Exception ex)
            {
                // log the exception and figure out what's happening
                _logger.LogError(ex, "Error searching for movies");
                movies = new List<MovieInfo>(); // this method never returns 404 so send an empty movie list instead
                // would be a little better to allow it to return a 404 and use that for the case where we really don't get back any results
            }
            
            return Ok(movies.OrderByDescending(m => m.Popularity));
        }

        // GET: api/movie/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type=typeof(Movie))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Movie>> MovieDetailAsync([FromRoute] int id)
        {
            Movie movie;
            try
            {
                movie = await _showService.MovieDetailAsync(id);
                // uncomment to manually test the error handling in the JS
                //throw new Exception();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting movie details");
                return NotFound();
            }

            return Ok(movie);
        }

        // GET: api/movie/5/credits
        [HttpGet("{id}/credits")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Credit>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Credit>>> MovieCreditsAsync([FromRoute] int id)
        {
            IEnumerable<Credit> credits;
            try
            {
                credits = await _showService.MovieCreditsAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting movie credits");
                return NotFound();
            }

            return Ok(credits);
        }

    }
}
