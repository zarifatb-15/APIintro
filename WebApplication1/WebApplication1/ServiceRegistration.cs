using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1;

public static class ServiceRegistration
{
    public static void AddServices(this IServiceCollection services, IConfiguration config)
    {
       services.AddControllers();
       services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("Default"));
        });
       
       // swagger services
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
    }
    
}