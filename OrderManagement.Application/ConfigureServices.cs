using Microsoft.Extensions.DependencyInjection;
using OrderManagement.Application.Interface;
using OrderManagement.Application.Repositiry;
using OrderManagement.Application.Services;

namespace OrderManagement.Application
{
    public static class ConfigureServices
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICustomer, CustomerService>();
            services.AddScoped<IOrder, OrderService>();
        }
    }
}
