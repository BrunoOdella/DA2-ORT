using DominioComun;
using LogicInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class MovieLogic : IMovieLogic
    {
        public Movie CreateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Movie GetMovieByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetMoviesByPosFtix(string postfix)
        {
            throw new NotImplementedException();
        }
    }
}
