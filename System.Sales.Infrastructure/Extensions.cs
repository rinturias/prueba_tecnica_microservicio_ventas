using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Sales.Infrastructure.EF.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Sales.Domain.Interfaces;
using System.Sales.Infrastructure.Repositories;
using System.Sales.Infrastructure.EF;
using System.Sales.Application;
using MassTransit;
using Microsoft.EntityFrameworkCore.Migrations;

namespace System.Sales.Infrastructure
{
    public static class Extensions
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
         
            services.AddMediatR(Assembly.GetExecutingAssembly());
            var connectionString = configuration.GetConnectionString("SalesDbConnectionString");

            services.AddDbContext<ReadDbContext>(context => context.UseSqlServer(connectionString));
            services.AddDbContext<WriteDbContext>(context => context.UseSqlServer(connectionString));

          

            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            AddRabbitMq(services, configuration);

            return services;
        }


		private static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
		{
			var rabbitMqHost = configuration["RabbitMq:Host"];
			var rabbitMqPort = configuration["RabbitMq:Port"];
			var rabbitMqUserName = configuration["RabbitMq:UserName"];
			var rabbitMqPassword = configuration["RabbitMq:Password"];

			services.AddMassTransit(config => {
				

				config.UsingRabbitMq((context, cfg) => {
					var uri = string.Format("amqp://{0}:{1}@{2}:{3}", rabbitMqUserName, rabbitMqPassword, rabbitMqHost, rabbitMqPort);
					cfg.Host(uri);

					
				});
			});
		}
	}
}
