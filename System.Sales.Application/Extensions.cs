using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Sales.Domain.Factories;
using System.Text;
using System.Threading.Tasks;

namespace System.Sales.Application
{

        public static class Extensions
        {
            public static IServiceCollection AddApplication(this IServiceCollection services)
            {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddTransient<IVueloServices, VueloServices>();
            services.AddTransient<ISaleFactory, SaleFactory>();
                return services;
            }

        }
    
}
