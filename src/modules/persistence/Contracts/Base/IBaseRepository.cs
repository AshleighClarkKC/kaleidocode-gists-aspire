using Kaleidocode.Gists.Modules.Persistence.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidocode.Gists.Modules.Persistence.Contracts.Base;

/// <summary>
/// Base repository type for usage with commands/queries. Provides basic CRUD for data access/mutation.
/// </summary>
/// <typeparam name="TEntity">The data type to be persisted to the database. Must inherit from <see cref="BaseEntity{TUserId}"/> since that provides an ID and auditing properties.</typeparam>
/// <typeparam name="TUserId">The data type to be used for User ID values.</typeparam>
public interface IBaseRepository<TEntity, TUserId> where TEntity : BaseEntity<TUserId> where TUserId : struct
{
    Task InsertAsync(TEntity model, TUserId? requesterId = null, Func<Exception, Task>? onFailureAsync = null);

    Task InsertRange(IEnumerable<TEntity> models, TUserId? requesterId = null, Func<Exception, Task>? onFailureAsync = null);

    Task<TEntity?> GetByIdAsync<TId>(TId id, Func<Exception, Task>? onFailureAsync = null);

    Task<IQueryable<TEntity>?> ListAsync(int limit, Func<Exception, Task>? onFailureAsync = null);

    Task UpdateAsync(TEntity model, TUserId? requesterId = null, Func<Exception, Task>? onFailureAsync = null);

    Task UpdateRangeAsync(IEnumerable<TEntity> models, TUserId? requesterId = null, Func<Exception, Task>? onFailureAsync = null);

    Task DeleteAsync<TId>(TId id, TUserId? requesterId = null, Func<Exception, Task>? onFailureAsync = null);

    Task DeleteRangeAsync<TId>(IEnumerable<TId> ids, TUserId? requesterId = null, Func<Exception, Task>? onFailureAsync = null);
}

