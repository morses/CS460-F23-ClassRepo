using HW2.Models;

namespace HW2.DAL.Abstract;

public interface IShowRepository : IRepository<Show>
{
    /// <summary>
    /// Returns a tuple of the total number of shows, movies, and tv shows in the database.
    /// </summary>
    (int show, int movie, int tv) NumberOfShowsByType();

    /// <summary>
    /// Find the show with the highest TMDB popularity.
    /// </summary>
    /// <returns>The show or null if there are no shows</returns>
    Show HighestTMDBPopularity();

    /// <summary>
    /// Find the show with the most IMDB votes.
    /// </summary>
    /// <returns>The show or null if there are no shows</returns>
    Show MostIMDBVotes();

    /// <summary>
    /// Determine the maximum value of the TMDB popularity of any show in the database.
    /// </summary>
    /// <returns>The value or -1 if there are no shows</returns>
    double MaxTmdbPopularity();

    /// <summary>
    /// Determine the maximum value of the IMDB votes count of any show in the database.
    /// </summary>
    /// <returns>The value or -1 if there are no shows</returns>
    double MaxImdbVotes();

    /// <summary>
    /// Helper method to transform a list of show ids into a list of show titles, ordered alphabetically.
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    List<string> GetShowTitlesByIds(IEnumerable<int> ids);
}