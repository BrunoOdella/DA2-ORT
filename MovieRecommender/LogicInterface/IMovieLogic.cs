using DominioComun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicInterface
{
    public interface IMovieLogic
    {
        IEnumerable<Movie> GetMoviesByPosFtix(string postfix);
        Movie GetMovieByTitle(string title);
        Movie CreateMovie(Movie movie);
    }
}
