
using Microsoft.Extensions.DependencyInjection;
using Models;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public static class ServiceCollectionExtensions
    {


        public static void RegisterDB(this IServiceCollection serviceCollection)

        {

            serviceCollection.AddDbContext<TaskManagerContext>();

            serviceCollection.AddScoped<BaseRepository<User>>();
            serviceCollection.AddScoped<BaseRepository<Tasks>>();

        }
    }
}