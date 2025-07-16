using ecommerce.Core.ServiceContract;
using ecommerce.Core.Services;
using ecommerce.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Core
{
    public static class DependencyInjection
    {
        /// <summary>
        ///  Extension method to add Core
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            // To Do : Add Services to the IOC Container
            // Core services ofter include data access ,caching and other low-level componenets.

            services.AddTransient<IUserService,UserService>();
            services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

            return services;
        }


    }
}
