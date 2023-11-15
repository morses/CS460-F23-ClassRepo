using HW4.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;

namespace HW4.Services
{
    class MoviesResponse
    {
        public int page { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
        public IList<MovieInfo> results { get; set; }
    }

    class CreditResponse
    {
        public int id { get; set; }
        public IList<Credit> cast { get; set; }
    }

    public class TmdbShowService : IShowService
    {
        // This http client is assumed to be pre-configured with the Authorization: Bearer ___ header
        private readonly HttpClient _httpClient;
        private readonly ILogger<TmdbShowService> _logger;
        public string PlaceholderURL { get; set; } = "https://via.placeholder.com/500x750.png?text=No+Image+Available";

        public TmdbShowService(HttpClient httpClient,ILogger<TmdbShowService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        // A generic method to send a request to any endpoint and deserialize the response into the specified type
        // Nicely reusable.
        public async Task<T> SendRequest<T>(string endpoint)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
            string responseBody;
            if (response.IsSuccessStatusCode)
            {
                responseBody = await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");       // TODO: use a suitably typed exception
            }

            // We used upper case names in the MovieInfo class so we need to turn off case-sensitivity when deserializing
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<T>(responseBody, options);
        }

        // All these service methods will throw exceptions from the underlying HTTP request and JSON deserialization
        public async Task<IEnumerable<MovieInfo>> SearchMoviesByTitleAsync(string title)
        {
            string endpointWithQuery = $"search/movie?query={Uri.EscapeDataString(title)}&include_adult=false&language=en-US&page=1";
            _logger.LogInformation($"Calling endpoint: {endpointWithQuery}");
            
            MoviesResponse moviesResponse = await SendRequest<MoviesResponse>(endpointWithQuery);

            IList<MovieInfo> movies = moviesResponse.results;
            foreach(var mi in movies)
            {
                // Really should let the front end decide on the image size, but for simplicity we'll just use the 500px wide image
                // and they can scale it down if they want.
                mi.PosterPath = String.IsNullOrEmpty(mi.PosterPath) ? PlaceholderURL : $"https://image.tmdb.org/t/p/w500{mi.PosterPath}";
                mi.ReleaseDate = ConvertDateToHumanReadableForm(mi.ReleaseDate);
            }

            return moviesResponse.results.OrderByDescending(mi => mi.Popularity);
        }

        public async Task<Movie> MovieDetailAsync(int id)
        {
            string endpointWithQuery = $"movie/{id}?language=en-US";
            _logger.LogInformation($"Calling endpoint: {endpointWithQuery}");
            Movie movie = await SendRequest<Movie>(endpointWithQuery);
            movie.ReleaseDate = ConvertDateToHumanReadableForm(movie.ReleaseDate);
            movie.PosterPath = String.IsNullOrEmpty(movie.PosterPath) ? PlaceholderURL : $"https://image.tmdb.org/t/p/w500{movie.PosterPath}";
            movie.BackdropPath = String.IsNullOrEmpty(movie.BackdropPath) ? PlaceholderURL : $"https://image.tmdb.org/t/p/w780{movie.BackdropPath}";
            return movie;
        }

        public async Task<IEnumerable<Credit>> MovieCreditsAsync(int id)
        {
            string endpointWithQuery = $"movie/{id}/credits?language=en-US";
            _logger.LogInformation($"Calling endpoint: {endpointWithQuery}");
            CreditResponse creditResponse = await SendRequest<CreditResponse>(endpointWithQuery);
            return creditResponse.cast;
        }

        // This is one of the two pieces of functionality we needed to test.  The other one is implemented in JS
        // and I'll use it to demonstrate unit testing in JS later

        public static string ConvertDateToHumanReadableForm(string dateString)
        {
            DateTime dateValue;
            if(DateTime.TryParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
            {
                return dateValue.ToString("MMMM d, yyyy");
            }
            else
            {
                return "not available";
            }
        }

    }


}
