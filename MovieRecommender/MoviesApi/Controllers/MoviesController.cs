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

        private IMovieLogic _movieLogic;
        public MoviesController(IMovieLogic movieLogic)
        {
            this._movieLogic = movieLogic;
        }

        [HttpGet("{title}")]
        public IActionResult GetMovieByTitle(string title)
        {
            // Llamada a la lógica de negocio para obtener la película por su título.
            CreateMovieResponse movieResponse = _movieLogic.GetMovieByTitle(title);

            // Verificar que se encontró una película.
            if (movieResponse == null)
            {
                return NotFound(); // Si no se encuentra la película, devuelve un error 404.
            }

            // Devuelve el modelo de respuesta con un estado 200 OK.
            return Ok(movieResponse);
        }




        [HttpPost]
        public IActionResult CreateMovie([FromBody] CreateMovieRequest movieRequest)
        {
            // Aquí llamas al método de la lógica de negocio para crear la película y obtener la respuesta.
            CreateMovieResponse movieResponse = _movieLogic.CreateMovie(movieRequest);

            // Verifica si se devolvió una respuesta (puede ser null si la creación falló).
            if (movieResponse == null)
            {
                // Manejar el caso en que la película no se pudo crear.
                return BadRequest("No se pudo crear la película.");
            }

            // Si CreateMovie fue exitoso, devuelves un resultado 201 Created con la respuesta apropiada.
            // Asegúrate de tener un método GetMovieByTitle que pueda manejar esta solicitud.
            return CreatedAtAction(nameof(GetMovieByTitle), new { title = movieResponse.Title }, movieResponse);
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



        // GET: api/movies
        //[HttpGet]
        //public IActionResult GetAllMovies()
        //{
        //    return new OkObjectResult("Barbie, Oppenheimer, Shrek 2, Harry Potter 2");
        //}

    }
}
