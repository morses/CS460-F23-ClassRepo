using GitHubApp.Models;
using GitHubApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GitHubApp.Controllers
{
    [Route("api/github")]
    [ApiController]
    public class GitHubApiController : ControllerBase
    {

        private readonly IGitHubService _gitHubService;
        private readonly ILogger<GitHubApiController> _logger;

        public GitHubApiController(IGitHubService gitHubService, ILogger<GitHubApiController> logger)
        {
            _gitHubService = gitHubService;
            _logger = logger;
        }

        // GET: api/github/search/repositories?q=Q
        [HttpGet("search/repositories")]
        [ProducesResponseType(StatusCodes.Status200OK, Type=typeof(IEnumerable<GitRepo>))]
        public async Task<ActionResult<IEnumerable<GitRepo>>> SearchRepositoriesAsync(string q)
        {
            try
            {
                IEnumerable<GitRepo> repos = await _gitHubService.SearchRepositoriesAsync(q);
                return Ok(repos);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error searching GitHub repositories");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
