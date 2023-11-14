using System.Text.Json.Serialization;

namespace HW4.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Movie
    {
        [JsonPropertyName("backdrop_path")]
        public string BackdropPath { get; set; }
        public double Budget { get; set; }
        public IList<Genre> Genres { get; set; }
        public string Homepage { get; set; }
        public int Id { get; set; } 
        public string ImdbId { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }

        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }
        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }
        public double Revenue { get; set; }
        public double Runtime { get; set; }
        public string Title { get; set; }
    }
}
