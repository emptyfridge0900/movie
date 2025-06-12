using Movie.Models;

namespace Movie.Services;

public class MovieService (HttpClient Client) : IMovieService
{
    public async Task<Result> SearchMovies(string title, string year, int page)
    {
        var url = year is null 
            ? $"?apikey=72a5618d&s={title}&page={page}" 
            : $"?apikey=72a5618d&s={title}&y={year}&page={page}";
        var response = await Client.GetAsync(url);

        using HttpContent content = response.Content;
        string responseBody = await response.Content.ReadAsStringAsync();
        var re = System.Text.Json.JsonSerializer.Deserialize<Result>(responseBody);
        return re;
    }

    public async Task<MovieInfo> GetMovieInfo(string imdbId)
    {
        var response = await Client.GetAsync($"?apikey=72a5618d&i={imdbId}");
        using HttpContent content = response.Content;
        string responseBody = await response.Content.ReadAsStringAsync();
        var info = System.Text.Json.JsonSerializer.Deserialize<MovieInfo>(responseBody); 
        return info;
    }
}