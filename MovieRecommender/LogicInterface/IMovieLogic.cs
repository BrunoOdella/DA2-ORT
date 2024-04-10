using DominioComun;
using Models.In;
using Models.Out;

namespace LogicInterface
{
    public interface IMovieLogic
    {
        IEnumerable<Movie> GetMoviesByPosFtix(string postfix);
        CreateMovieResponse GetMovieByTitle(string title);
        CreateMovieResponse CreateMovie(CreateMovieRequest movie);
    }
}
