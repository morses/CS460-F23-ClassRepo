using HW2.Models;

namespace HW2.DAL.Abstract;

public interface IRoleRepository : IRepository<Role>
{
    /// <summary>
    /// Find the Person with the most credits where role is DIRECTOR and return their ID, and list of show id's.
    /// </summary>
    (int, IEnumerable<int>) DirectorWithTheMostShows();

}