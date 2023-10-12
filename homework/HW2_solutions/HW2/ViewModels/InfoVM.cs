using HW2.Models;

namespace HW2.ViewModels
{
    public class InfoVM
    {
        public int NumberOfShows { get; set; }
        public int NumberOfMovies { get; set; }
        public int NumberOfTVShows { get; set; }
        public Show ShowWithHighestTMDBPopularity { get; set; }
        public Show ShowWithMostIMDBVotes { get; set; }

        public List<string> Genres { get; set; } 

        public string DirectorNameWithMostShows { get; set; }
        public List<string> ShowsForDirectorWithMost { get; set; }

    }
}
