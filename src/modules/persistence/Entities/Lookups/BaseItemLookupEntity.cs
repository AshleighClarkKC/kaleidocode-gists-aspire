using Kaleidocode.Gists.Modules.Persistence.Entities.Base;

namespace Kaleidocode.Gists.Modules.Persistence.Entities.Lookups;

/// <summary>
/// The base structure for lookup entities to be created, based on the <see cref="BaseEntity{TUserId}"/> type.
/// </summary>
/// <typeparam name="TUserId">The user ID type, based on the typeparam from <see cref="BaseEntity{TUserId}"/>.</typeparam>
public class BaseItemLookupEntity<TUserId> : BaseEntity<TUserId> where TUserId : struct
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}
