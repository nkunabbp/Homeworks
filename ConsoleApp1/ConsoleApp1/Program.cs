var cinema = new CinemaFacade();
cinema.AddMovieToDataBase(new Movie
{
    Title = "Drive",
    Cast = "Ryan Gosling",
    Director = "Ryan Gosling",
    Writer = "Ryan Gosling",
    Rating = 10.0
});

Console.WriteLine(cinema.GetMovieDetails("Drive"));

public class Movie
{
    public string? Title { get; set; }
    public string? Cast { get; set; } // Cast mojet bit i ne iz odnogo celoveka no ya tak sdelala radi primera
    public string? Director { get; set; }
    public string? Writer { get; set; }
    public double Rating { get; set; }

    public override string ToString()
    {
        return $"Title : {Title}\n" +
               $"Cast : {Cast}\n" +
               $"Director : {Director}\n" +
               $"Writer : {Writer}\n" +
               $"Rating : {Rating}";
    }
}

public class CinemaFacade
{
    private readonly Cinema _cinema;

    public CinemaFacade()
    {
        _cinema = new Cinema();
    }

    public Movie? GetMovieDetails(string title)
    {
        return _cinema?.GetMovieDetails(title);
    }

    public void AddMovieToDataBase(Movie movie)
    {
        _cinema.AddMovie(movie);
    }

    public string? GetCastList(string title)
    {
        var movie = _cinema.GetMovieDetails(title);
        return movie?.Cast;
    }

    public string? GetDirector(string title)
    {
        var movie = _cinema.GetMovieDetails(title);
        return movie?.Director;
    }
}

public class Cinema
{
    private List<Movie> _movies;

    public Cinema()
    {
        _movies = new List<Movie>();
    }

    public void AddMovie(Movie movie)
    {
        foreach (var item in _movies)
        {
            if (item.Title == movie.Title)
            {
                Console.WriteLine("Movie Is Already Existing");
                return;
            }
        }

        _movies.Add(movie);
    }

    public Movie? GetMovieDetails(string title)
    {
        foreach (var item in _movies)
        {
            if (item.Title == title)
            {
                return item;
            }
        }

        return null;
    }
}