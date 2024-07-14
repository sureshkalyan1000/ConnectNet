using ConnectNet.Entities;
using ConnectNet.IRepository;
using ConnectNet.Repository;
using Microsoft.EntityFrameworkCore;

namespace ConnectNet.Extensions
{
    public static class AddApplicationServices
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration config)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<DataContext>(Options =>
            Options.UseSqlServer(config.GetConnectionString("devconnection")));

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
