using System.Text.Json.Serialization;

namespace HW4.Models
{
    public class MovieInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Overview { get; set; }

        public double Popularity { get; set; }

        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }

        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }

    }
}
