using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HW2.DAL.Abstract;
using HW2.Models;

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
        int numShows  = _shows.Count();
        int numMovies = _shows.Where(s => s.ShowType.ShowTypeIdentifier == "MOVIE").Count();
        int numTVs    = _shows.Where(s => s.ShowType.ShowTypeIdentifier == "SHOW").Count();
        return (numShows,numMovies,numTVs);
    }

    public Show HighestTMDBPopularity()
    {
        return _shows.OrderBy(s => s.TmdbPopularity).LastOrDefault();
    }

    public Show MostIMDBVotes()
    {
        return _shows.OrderByDescending(s => s.ImdbVotes).FirstOrDefault();
    }

    public double MaxTmdbPopularity()
    {
        return _shows.Select(s => s.TmdbPopularity).Max().GetValueOrDefault();
    }

    public double MaxImdbVotes()
    {
        return _shows.Select(s => s.ImdbVotes).Max().GetValueOrDefault();
    }

    public List<string> GetShowTitlesByIds(IEnumerable<int> ids)
    {
        return _shows.Where(s => ids.Contains(s.Id)).Select(s => s.Title).OrderBy(s => s).ToList();
    }
}