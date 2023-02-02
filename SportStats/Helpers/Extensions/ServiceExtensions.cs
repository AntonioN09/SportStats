using Microsoft.AspNetCore.Cors.Infrastructure;
using SportStats.Controllers.Jwt;
using SportStats.Helpers.Seeders;
using SportStats.Repositories.EventRepository;
using SportStats.Repositories.ManagerRepository;
using SportStats.Repositories.PlayerRepository;
using SportStats.Repositories.TeamRepository;
using SportStats.Services.EventService;
using SportStats.Services.ManagerService;
using SportStats.Services.PlayerService;
using SportStats.Services.TeamService;

namespace SportStats.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<IManagerRepository, ManagerRepository>();
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IManagerService, ManagerService>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<ITeamService, TeamService>();

            return services;
        }

        public static IServiceCollection AddSeeders(this IServiceCollection services)
        {
            services.AddTransient<ManagerSeeder>();

            return services;
        }

        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            services.AddTransient<IJwtUtils, JwtUtils>();

            return services;
        }
    }
}
