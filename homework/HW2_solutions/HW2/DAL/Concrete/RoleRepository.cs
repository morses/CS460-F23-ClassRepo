using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HW2.DAL.Abstract;
using HW2.Models;

namespace HW2.DAL.Concrete;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    private DbSet<Role> _roles;

    public RoleRepository(StreamingDbContext context) : base(context)
    {
        _roles = context.Roles;
    }

    public (int, IEnumerable<int>) DirectorWithTheMostShows()
    {
        try
        {
            // When this version is translated into SQL by LINQ it results in a separate call
            // to the db for every person and is thus very slow and inefficient
            /*
            var directorShows = _roles.First(r => r.RoleName == "DIRECTOR")
						          .Credits
						          .GroupBy(c => c.Person.Id)
						          .OrderByDescending(gp => gp.Count())
						          .First()
						          .Select( g => new {Director = g.Person, Show = g.Show} );
            int id = directorShows.First().Director.Id;
            string name = directorShows.First().Director.FullName;
            IEnumerable<Show> shows = directorShows.Select(ds => ds.Show);
            */
            // This version only makes 2 initial calls to the db to retrieve all credits that have role as director
            // and does the rest in memory, until retrieving show info for each show for that director.  
            // Would be nice to do it all on the db in one query.
            var directorShows = _roles.First(r => r.RoleName == "DIRECTOR")
						.Credits
						.Select(c => new {ShowId = c.ShowId, PersonId = c.PersonId})
						.GroupBy(c => c.PersonId)
						.OrderByDescending(gp => gp.Count())
						.First();
            int id = directorShows.Key;
        

            return (directorShows.Key,directorShows.Select(ds => ds.ShowId));
        }
        catch(InvalidOperationException e)
        {
            return (0,Enumerable.Empty<int>());
        }
        
    }
}