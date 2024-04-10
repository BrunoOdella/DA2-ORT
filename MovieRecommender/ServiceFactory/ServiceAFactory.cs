using LogicInterface;
using BusinessLogic.Logic;
using Microsoft.Extensions.DependencyInjection;
using IDataAccess;
using DataAccess;

namespace ServiceFactory
{
    public static class ServiceAFactory
    {
        public static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMovieLogic, MovieLogic>();
            serviceCollection.AddScoped<IReviewLogic, ReviewLogic>();
            serviceCollection.AddScoped<IMovieRepository, MovieRepository>();
        }
    }
}
