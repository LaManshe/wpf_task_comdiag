using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using wpf_task.DAL;
using wpf_task.DAL.Data;



namespace wpf_task.Data
{
    static class DbRegistrator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            return services
            .AddDbContext<AppDbContext>(
                options => options.UseMySql(configuration.GetConnectionString("LocalCS_MySql"), new MySqlServerVersion(new Version(8, 0, 29))))
            .AddRepositoriesInDB()
            ;
        }
    }
}
