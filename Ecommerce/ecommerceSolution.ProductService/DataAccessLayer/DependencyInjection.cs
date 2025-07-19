using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using DataAccessLayer.RepositoryContract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccesslayer(this IServiceCollection services,IConfiguration config)
        {
            // To Do Add Data Access layer service into Ioc Containers.
             
            services.AddDbContext<ApplicationDbContext>(
                x =>
                {
                    x.UseMySQL(config.GetConnectionString("ConnectionString")!);
                });


            services.AddScoped<IProductRepository, ProductsRepositories>();
            return services;
        }
    }
}
