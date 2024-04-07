using LogicInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using MoviesApi.Models.In;
using MoviesApi.Models.Out;
using System.Reflection;

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


        private IMovieLogic movieLogic;
        public MoviesController(IMovieLogic movieLogic)
        {
            this.movieLogic = movieLogic;
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
        public IActionResult CreateMovie([FromBody] CreateMovieRequest movie)
        {
            CreateMovieResponse response = new CreateMovieResponse()
            {
               Title = movie.Title,
               Genres = movie.Genres,
            };
            return CreatedAtAction(nameof(GetMovieByTitle), new { title = response.Title }, response);
        }
    }
}
