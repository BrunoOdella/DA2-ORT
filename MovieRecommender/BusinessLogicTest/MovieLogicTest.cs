using BusinessLogic.Logic;
using IDataAccess;
using LogicInterface;
using Moq;

namespace BusinessLogicTest;

[TestClass]
public class MovieLogicTest
{
  


    [TestMethod]
    public void GetMovieByTitleNonExistingTitle()
    {
        //arrange
        string title = "Shrek 4";
        Mock<IMovieRepository> movieRepositoryMock = new Mock<IMovieRepository>(MockBehavior.Strict);
        movieRepositoryMock.Setup(repository => repository.GetMovieByTitle(It.IsAny<string>())).Throws(new ArgumentException("There is no such a movie"));
        IMovieLogic movieLogic = new MovieLogic(movieRepositoryMock.Object);
        Exception exception = null;

        //Act
        try {
            movieLogic.GetMovieByTitle(title); }
        catch (Exception ex) { exception = ex; }
        //Assert
        movieRepositoryMock.VerifyAll();
        Assert.IsInstanceOfType(exception, typeof(ArgumentException));
        Assert.IsTrue(exception.Message.Equals("There is no such a movie"));
    }
}

