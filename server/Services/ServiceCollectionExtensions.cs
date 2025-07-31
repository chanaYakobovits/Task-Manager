using Microsoft.Extensions.DependencyInjection;
using Services.Iservice;
using Services.Services;


namespace Services
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<ITasksService, TasksService>();

        }
    }
}
