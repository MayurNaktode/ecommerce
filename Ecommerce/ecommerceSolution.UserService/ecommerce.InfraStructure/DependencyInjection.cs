using ecommerce.Core.RepositoryContract;
using ecommerce.InfraStructure.DbContext;
using ecommerce.InfraStructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.InfraStructure
{
    public static class DependencyInjection
    {
        /// <summary>
        ///  Extension method to add infrastructure
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfraStructure(this IServiceCollection services)
        {
            // To Do : Add Services to the IOC Container
            // Infrastructure services ofter include data access ,caching and other low-level componenets.

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<DapperDbContext>();

            return services;
        }


    }
}
