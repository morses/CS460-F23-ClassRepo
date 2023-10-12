using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HW2.DAL.Abstract;
using HW2.Models;

namespace HW2.DAL.Concrete;

public class GenreRepository : Repository<Genre>, IGenreRepository
{
    private DbSet<Genre> _genres;

    public GenreRepository(StreamingDbContext context) : base(context)
    {
        _genres = context.Genres;
    }

    public List<string> GenreNames()
    {
        return _genres.OrderBy(g => g.GenreString).Select(g => g.GenreString).ToList();
    }

}