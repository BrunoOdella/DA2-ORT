using DominioComun;

namespace LogicInterface
{
    public interface IMovieLogic
    {
        IEnumerable<Movie> GetMoviesByPosFtix(string postfix);
        Movie GetMovieByTitle(string title);
        Movie CreateMovie(Movie movie);
    }
}
