using System.Linq;
using Microsoft.EntityFrameworkCore;
using HW2.DAL.Abstract;
using HW2.Models;

// And the associated implementation, stubbed out for you.
// Put this in folder DAL/Concrete

namespace HW2.DAL.Concrete;

public class ShowRepository : Repository<Show>, IShowRepository
{
    private DbSet<Show> _shows;

    public ShowRepository(StreamingDbContext context) : base(context)
    {
        _shows = context.Shows;
    }

    public (int show, int movie, int tv) NumberOfShowsByType()
    {
        // Use _shows to get what you need.  We purposefully don't have access to other dbSets.
        return (0,0,0);
    }

    public Show ShowWithHighestTMDBPopularity()
    {
        return null;
    }

    public Show ShowWithMostIMDBVotes()
    {
        return null;
    }

}