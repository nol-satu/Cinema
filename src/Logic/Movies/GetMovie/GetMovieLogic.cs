namespace Logic.Movies.GetMovie;

public class GetMovieLogic(DataAccessService dataAccessService): IRequestHandler<GetMovieInput, GetMovieOutput>
{
    public async Task<GetMovieOutput> Handle(GetMovieInput input, CancellationToken cancellationToken = default)
    {
        var movie = await dataAccessService.Movies
            .Where(x => x.Id == input.Id)
            .SingleAsync(cancellationToken);

        //var output = new GetMovieOutput
        //{
        //    Id = movie.Id,
        //    Title = movie.Title,
        //    Synopsis = movie.Synopsis,
        //    ReleaseDate = movie.ReleaseDate,
        //    Rating = movie.Rating,
        //    TicketPrice = movie.TicketPrice,
        //};

        return movie.Adapt<GetMovieOutput>();
    }
}