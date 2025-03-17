using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProvaPub.Application.Mappings;
using ProvaPub.Application.Services;
using ProvaPub.Application.Services.Interfaces;
using ProvaPub.Domain.Repositories;
using ProvaPub.Infra.Data.Context;
using ProvaPub.Infra.Data.Repositories;

namespace ProvaPub.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ctx")));

            services.AddScoped<IRandomRepository, RandomRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


            return services;
        }

        public static IServiceCollection AddServices(
           this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDTOMapping));
            services.AddScoped<IRandomService, RandomService>();
            services.AddScoped<IProductService, ProductsService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOrderService, OrderService>();

            return services;
        }
    }
}

