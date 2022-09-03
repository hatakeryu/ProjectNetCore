using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Mongo.Base;
using Persistence.Mongo.Interfaces;
using Persistence.Mongo.Repositories;

namespace Persistence
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddPersistence(this IServiceCollection service, IConfiguration configuration)
    {
      service.AddScoped<IProjectNetCoreDbContext, ProjectNetCoreDbContext>();
      service.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
      service.AddScoped<IPersonMongoRepository, PersonMongoRepository>();

      return service;
    }

    public static IServiceCollection AddPersistenceProduction(this IServiceCollection service, IConfiguration configuration)
    {
      service.AddPersistence(configuration);

      service.AddDbContext<IProjectNetCoreDbContext, ProjectNetCoreDbContext>(
        options => options.UseSqlServer(configuration.GetConnectionString("SQLServer"), providerOptions => providerOptions.CommandTimeout(60))
                  .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
        );

      return service;
    }
  }
}
