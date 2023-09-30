using HW2.Models;

// Here is a starting point to help you use a good testable design for your application logic
// It uses the generic repository pattern, which is a common pattern for data access in .NET
// Put this in a DAL/Abstract folder (DAL stands for Data Access Layer)

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
    Show ShowWithHighestTMDBPopularity();

    /// <summary>
    /// Find the show with the most IMDB votes.
    /// </summary>
    /// <returns>The show or null if there are no shows</returns>
    Show ShowWithMostIMDBVotes();
}