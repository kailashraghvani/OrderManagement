using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OrderManagement.Data
{
    public static class ConfigureDBContext
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var conString = configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrWhiteSpace(conString)) 
            {
                throw new ArgumentNullException("Connection string not specified.");
            }
            services.AddDbContext<ApplicationDBContex>(option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
