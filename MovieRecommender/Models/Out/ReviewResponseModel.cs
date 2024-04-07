using DominioComun;

namespace Models.Out
{
    public class ReviewResponseModel
    {
        public Movie Movie { get; set; }
        public double Rating { get; set; }

        public ReviewResponseModel(Review review)
        {
            Movie = review.Movie;
            Rating = review.Rating;
        }

    }
}
