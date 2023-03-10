using Application.Interfaces;
using Infrastructure.Repositories;

namespace Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ITaskToDoRepository, TaskToDoRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
