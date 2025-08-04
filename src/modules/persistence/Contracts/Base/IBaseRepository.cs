using Kaleidocode.Gists.Modules.Persistence.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidocode.Gists.Modules.Persistence.Contracts.Base;

public interface IBaseRepository<TEntity, TUserId> where TEntity : BaseEntity<TUserId> where TUserId : struct
{
    Task InsertAsync(TEntity model, TUserId requesterId, Func<Exception, Task>? onFailureAsync = null);

    Task InsertRange(IEnumerable<TEntity> models, TUserId requesterId, Func<Exception, Task>? onFailureAsync = null);

    Task<TEntity?> GetByIdAsync<TId>(TId id, Func<Exception, Task>? onFailureAsync = null);

    Task<IQueryable<TEntity>?> ListAsync(int limit, Func<Exception, Task>? onFailureAsync = null);

    Task UpdateAsync(TEntity model, TUserId requesterId, Func<Exception, Task>? onFailureAsync = null);

    Task UpdateRangeAsync(IEnumerable<TEntity> models, TUserId requesterId, Func<Exception, Task>? onFailureAsync = null);

    Task DeleteAsync<TId>(TId id, TUserId requesterId, Func<Exception, Task>? onFailureAsync = null);

    Task DeleteRangeAsync<TId>(IEnumerable<TId> ids, TUserId requesterId, Func<Exception, Task>? onFailureAsync = null);
}

