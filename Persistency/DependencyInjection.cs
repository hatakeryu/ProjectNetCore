using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Persistence
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddPersistence(this IServiceCollection service, IConfiguration configuration)
    {
      service.AddScoped<IProjectNetCoreDbContext, ProjectNetCoreDbContext>();
      return service;
    }

    public static IServiceCollection AddPersistenceProduction(this IServiceCollection service, IConfiguration configuration)
    {
      service.AddDbContext<IProjectNetCoreDbContext, ProjectNetCoreDbContext>(
        options => options.UseSqlServer(configuration.GetConnectionString("SQLServer"), providerOptions => providerOptions.CommandTimeout(60))
                  .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
        );

      return service;
    }
  }
}
