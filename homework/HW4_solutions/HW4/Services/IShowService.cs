using HW4.Models;
using System.ComponentModel.DataAnnotations;

namespace HW4.Services
{
    public interface IShowService
    {
        Task<IEnumerable<MovieInfo>> SearchMoviesByTitleAsync(string title);

        Task<Movie> MovieDetailAsync(int id);

        Task<IEnumerable<Credit>> MovieCreditsAsync(int id);
    }
}
