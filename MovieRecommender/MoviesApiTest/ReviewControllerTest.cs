using DominioComun;
using LogicInterface;
using Microsoft.AspNetCore.Mvc;
using Models.Out;
using Moq;
using MoviesApi.Controllers;

namespace MoviesApiTest;

[TestClass]
public class ReviewControllerTest
{
    private ReviewsController _reviewsController;


    [TestMethod]
    public void GetAllReviewsTestOk() {
        //Arrange
        Movie movie = new Movie()
        {
            Title = "Barbie",
            Genres = { }
        };
        IEnumerable<Review> reviews = new List<Review>()
            {
                new Review()
                {
                    Movie = movie,
                    Rating = 3.7
                }
            };

        Mock<IReviewLogic> reviewsLogicMock = new Mock<IReviewLogic>(MockBehavior.Strict);

        reviewsLogicMock.Setup(logic => logic.GetAllReviews())
            .Returns(reviews);

        _reviewsController = new ReviewsController(reviewsLogicMock.Object);

        OkObjectResult expected = new OkObjectResult(new List<ReviewResponseModel>()
        {
            new ReviewResponseModel(reviews.First())
        });
        List<ReviewResponseModel> expectedObject = expected.Value as List<ReviewResponseModel>;

        //Act
        OkObjectResult result = _reviewsController.GetAllReviews() as OkObjectResult;
        Console.WriteLine(result.Value);
        List<ReviewResponseModel> objectResult = result.Value as List<ReviewResponseModel>;

        //Assert
        reviewsLogicMock.VerifyAll();
        Assert.IsTrue(result.StatusCode.Equals(expected.StatusCode)
            && expectedObject.First().Movie.Title.Equals(objectResult.First().Movie.Title));

            
    }
}

