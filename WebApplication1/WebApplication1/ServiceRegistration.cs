using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Profiles;

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
        
        // httpcontextaccessor
        services.AddHttpContextAccessor();
        
        
        // AutoMapperservices
        services.AddAutoMapper(opt => opt.AddProfile(new MapperProfile(new HttpContextAccessor())));
    }
    
}