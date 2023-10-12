using HW2.Models;

namespace HW2.DAL.Abstract;

public interface IGenreRepository : IRepository<Genre>
{
    /// <summary>
    /// Returns a list of all the genres in the database, sorted alphabetically.
    /// </summary>
    List<string> GenreNames();

}