using Kaleidocode.Gists.Modules.Persistence.Contexts;
using Kaleidocode.Gists.Modules.Persistence.Contracts.Base;
using Kaleidocode.Gists.Modules.Persistence.Entities.Lookups;
using Kaleidocode.Gists.Modules.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Kaleidocode.Gists.Modules.Persistence.Repositories;

public class LookupRepository(MainContext context) : BaseRepository<BaseItemLookupEntity<Guid>, Guid>(context), IBaseRepository<BaseItemLookupEntity<Guid>, Guid>
{
    public override Task InsertAsync(BaseItemLookupEntity<Guid> model, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null)
    {
        return base.InsertAsync(model, requesterId, onFailureAsync);
    }

    public override Task InsertRange(IEnumerable<BaseItemLookupEntity<Guid>> models, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null)
    {
        return base.InsertRange(models, requesterId, onFailureAsync);
    }

    public override Task<BaseItemLookupEntity<Guid>?> GetByIdAsync<TId>(TId id, Func<Exception, Task>? onFailureAsync = null)
    {
        return base.GetByIdAsync(id, onFailureAsync);
    }

    public override Task<IQueryable<BaseItemLookupEntity<Guid>>?> ListAsync(int limit, Func<Exception, Task>? onFailureAsync = null)
    {
        return base.ListAsync(limit, onFailureAsync);
    }

    public override Task UpdateAsync(BaseItemLookupEntity<Guid> model, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null)
    {
        return base.UpdateAsync(model, requesterId, onFailureAsync);
    }

    public override Task UpdateRangeAsync(IEnumerable<BaseItemLookupEntity<Guid>> models, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null)
    {
        return base.UpdateRangeAsync(models, requesterId, onFailureAsync);
    }

    public override Task DeleteAsync<TId>(TId id, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null)
    {
        return base.DeleteAsync(id, requesterId, onFailureAsync);
    }

    public override Task DeleteRangeAsync<TId>(IEnumerable<TId> ids, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null)
    {
        return base.DeleteRangeAsync(ids, requesterId, onFailureAsync);
    }
}

