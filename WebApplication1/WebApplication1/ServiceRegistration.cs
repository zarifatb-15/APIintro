using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Profiles;
using WebApplication1.Services;

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
        services.AddAutoMapper(opt => 
            opt.AddProfile(new MapperProfile(new HttpContextAccessor())));
        services.AddValidatorsFromAssemblyContaining<Program>();

        services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequireUppercase = true;
                opt.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<AppDbContext>();
        
        // migrate database

        // using (var serviceScope = services.BuildServiceProvider().CreateScope())
        // {
        //     var dbContext = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
        //     dbContext.Database.Migrate();
        // }
        services.AddScoped<JwtService>();
        services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultScheme=JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
                })
            .AddJwtBearer("Bearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = config["Jwt:Issuer"],
                    ValidAudience = config["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]))
                };
            });
        services.AddAuthorization();

    }
    
}