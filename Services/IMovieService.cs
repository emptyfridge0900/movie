using Movie.Models;

namespace Movie.Services;

public interface IMovieService
{
    Task<Result> SearchMovies(string title, string year, int page);
    Task<MovieInfo> GetMovieInfo(string imdbId);
}