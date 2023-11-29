using Microsoft.Extensions.Logging;

namespace Logic.Movies.GetMovies;

public class GetMoviesLogic(DataAccessService dataAccessService, ILogger<GetMoviesLogic> logger)
    : IRequestHandler<GetMoviesInput, GetMoviesOutput>
{
    public async Task<GetMoviesOutput> Handle(GetMoviesInput input, CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"{nameof(GetMoviesLogic)}");

        var movies = await dataAccessService.Movies
            .Where(x => x.Rating >= input.MinimumRating)
            .ToListAsync(cancellationToken);

        return new GetMoviesOutput
        {
            Movies = movies.Adapt<List<MovieDto>>()
        };
    }
}