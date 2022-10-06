using Microsoft.Extensions.DependencyInjection;
using wpf_task.DAL.Entities;
using wpf_task.Interfaces;

namespace wpf_task.DAL
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoriesInDB(this IServiceCollection services) => services
            .AddTransient<IRepository<Book>, BookRepository>()
            .AddTransient<IRepository<Author>, Repository<Author>>()
        ;
    }
}
