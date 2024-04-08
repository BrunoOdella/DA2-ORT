using DominioComun;
using LogicInterface;
using Microsoft.AspNetCore.Mvc;
using Models.In;
using Models.Out;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        // GET: api/movies
        //[HttpGet]
        //public IActionResult GetAllMovies()
        //{
        //    return new OkObjectResult("Barbie, Oppenheimer, Shrek 2, Harry Potter 2");
        //}


        private IMovieLogic _movieLogic;
        public MoviesController(IMovieLogic movieLogic)
        {
            this._movieLogic = movieLogic;
        }


        [HttpGet]
        public IActionResult GetMovieByPostFix([FromQuery] string? endsWith)
        {
            string[] movies = { "Shrek 2", "Harry Potter 2", "Barbie", "Oppenheimer" };
            if (endsWith is null)
            {
                return Ok(movies);
            }
            return Ok(movies.Where(x => x.EndsWith(endsWith)).ToList());
        }


        [HttpGet("{title}")]
        public IActionResult GetMovieByTitle([FromRoute] string title)
        {
            IMovieLogic movieLogic;
            string[] movies = { "Shrek 2", "Harry Potter 2", "Barbie", "Oppenheimer" };
            return Ok(from movie in movies
                      where movie.ToLower().Equals(title.ToLower())
                      select movie);
        }

        [HttpPost]
        public IActionResult CreateMovie([FromBody] CreateMovieRequest movieRequest)
        {
            // Aquí llamas al método de la lógica de negocio para crear la película.
           Movie movie = _movieLogic.CreateMovie(new Movie
            {
                Title = movieRequest.Title,
                Genres = movieRequest.Genres
            });

            // Suponiendo que CreateMovie retorna un objeto Movie,
            // o posiblemente null si no se pudo crear por alguna razón.
            if (movie == null)
            {
                // Manejar el caso en que la película no se pudo crear
                return BadRequest();
            }

            // Si CreateMovie fue exitoso, construyes la respuesta usando los datos de la película creada.
            CreateMovieResponse response = new CreateMovieResponse()
            {
                Title = movie.Title,
                Genres = movie.Genres
            };

            // Y luego devuelves un resultado 201 Created con la respuesta apropiada.
            return CreatedAtAction(nameof(GetMovieByTitle), new { title = response.Title }, response);
        }
    }
}
