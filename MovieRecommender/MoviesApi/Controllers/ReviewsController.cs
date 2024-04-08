using DominioComun;
using LogicInterface;
using Microsoft.AspNetCore.Mvc;
using Models.Out;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private IReviewLogic _reviewLogic;

        public ReviewsController(IReviewLogic reviewLogic)
        {
            this._reviewLogic = reviewLogic;
        }

        [HttpGet]
        public IActionResult GetAllReviews()
        {
            IEnumerable<Review> reviews = _reviewLogic.GetAllReviews();
            if (reviews == null || !reviews.Any()) 
            {
                return NotFound();
            }
            var responseModels = reviews.Select(r => new ReviewResponseModel(r)).ToList();
            return Ok(responseModels);
        }

    }
}
