using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kaleidocode.Gists.Modules.Persistence.Extensions;

/// <summary>
/// Extension methods to inject persistence to API's.
/// </summary>
public static class PersistenceExtensions
{
    public static IServiceCollection AddContext<TContext>(this IServiceCollection svc) where TContext : DbContext
        => throw new NotImplementedException(message: "Note: Custom DB Context Injection is not ready as yet.");
    
}
