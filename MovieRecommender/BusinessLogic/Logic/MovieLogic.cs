using DominioComun;
using IDataAccess;
using LogicInterface;
using Models.In;
using Models.Out;

namespace BusinessLogic.Logic
{
    public class MovieLogic : IMovieLogic
    {

        private IMovieRepository _movieRepository;
        public MovieLogic(IMovieRepository movieRepository)
        {
            this._movieRepository = movieRepository;
        }


        public CreateMovieResponse GetMovieByTitle(string title)
        {
            // Utiliza el repositorio para obtener la entidad de dominio Movie.
            var movie = _movieRepository.GetMovieByTitle(title);

            // Si no hay ninguna película con ese título, devuelve null.
            if (movie == null)
            {
                return null;
            }

            // Convierte la entidad Movie a un DTO CreateMovieResponse.
            var movieResponse = new CreateMovieResponse
            {
                GUID = movie.Id,
                Title = movie.Title,
                Genres = movie.Genres
            };

            return movieResponse;
        }

        public CreateMovieResponse CreateMovie(CreateMovieRequest movie)
        {
            throw new NotImplementedException();
        }



        public IEnumerable<Movie> GetMoviesByPosFtix(string postfix)
        {
            throw new NotImplementedException();
        }

    }
}
