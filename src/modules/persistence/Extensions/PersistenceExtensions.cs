using Kaleidocode.Gists.Modules.Persistence.Contracts.Base;
using Kaleidocode.Gists.Modules.Persistence.Entities.Lookups;
using Kaleidocode.Gists.Modules.Persistence.Models.Commands;
using Kaleidocode.Gists.Modules.Persistence.Models.Queries;
using Kaleidocode.Gists.Modules.Persistence.Repositories;
using Kaleidocode.Gists.Modules.Persistence.Repositories.Base;
using LiteBus.Commands.Extensions.MicrosoftDependencyInjection;
using LiteBus.Messaging.Extensions.MicrosoftDependencyInjection;
using LiteBus.Queries.Extensions.MicrosoftDependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Kaleidocode.Gists.Modules.Persistence.Extensions;

/// <summary>
/// Extension methods to inject persistence to API's.
/// </summary>
public static class PersistenceExtensions
{
    public static IServiceCollection AddContext<TContext>(this IServiceCollection svc) where TContext : DbContext
        => svc.AddDbContext<TContext>();

    public static IServiceCollection AddLookupMediator(this IServiceCollection svc)
    {
        svc.AddLiteBus(lb =>
        {
            lb.AddCommandModule(
                mod => mod.RegisterFromAssembly(typeof(CreateLookupCommand<Guid>).Assembly)
            );
            lb.AddQueryModule(
                mod => mod.RegisterFromAssembly(typeof(GetLookupQuery<Guid>).Assembly)
            );
        });

        return svc;
    }

    public static IServiceCollection AddLookupPersistence(this IServiceCollection svc)
    {
        svc.AddLookupMediator();
        svc.AddScoped<IBaseRepository<BaseItemLookupEntity<Guid>, Guid>, LookupRepository>();
        return svc;
    }
    
}
