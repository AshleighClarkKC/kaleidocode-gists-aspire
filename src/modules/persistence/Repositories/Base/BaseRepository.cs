using Kaleidocode.Gists.Modules.Persistence.Contracts.Base;
using Kaleidocode.Gists.Modules.Persistence.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Kaleidocode.Gists.Modules.Persistence.Repositories.Base;

public class BaseRepository<TEntity, TUserId>(DbContext context) : IBaseRepository<TEntity, TUserId>
    where TEntity : BaseEntity<TUserId>
    where TUserId : struct
{
    private readonly DbContext _context = context;
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public async Task InsertAsync(TEntity model, TUserId requesterId, Func<Exception, Task>? onFailureAsync = null)
    {
        await using var _transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            model.CreatedDate = DateTime.Now;
            model.CreatedBy = requesterId;

            await _dbSet.AddAsync(model);
            await _context.SaveChangesAsync();

            await _transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            if (onFailureAsync != null)
            {
                await onFailureAsync(ex);
            }
            await _transaction.RollbackAsync();
        }
    }

    public async Task InsertRange(IEnumerable<TEntity> models, TUserId requesterId, Func<Exception, Task>? onFailureAsync = null)
    {
        await using var _transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            foreach (var model in models) 
            {
                model.CreatedDate = DateTime.Now;
                model.CreatedBy = requesterId;
            }

            await _dbSet.AddRangeAsync(models);
            await _context.SaveChangesAsync();

            await _transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            if (onFailureAsync != null)
            {
                await onFailureAsync(ex);
            }
            await _transaction.RollbackAsync();
        }
    }

    public async Task<TEntity?> GetByIdAsync<TId>(TId id, Func<Exception, Task>? onFailureAsync = null)
    {
        TEntity? value = null;

        try
        {
            value = await _dbSet.FindAsync(id);
        }
        catch (Exception ex)
        {
            if (onFailureAsync != null)
            {
                await onFailureAsync(ex);
            }

        }

        return value;
    }

    public async Task<IQueryable<TEntity>?> ListAsync(int limit, Func<Exception, Task>? onFailureAsync = null)
    {
        try
        {
            return (
                await _context.Set<TEntity>()
                .ToListAsync()
                )
            .AsQueryable()
            .Take(limit);
        }
        catch (Exception ex)
        {
            if (onFailureAsync != null)
            {
                await onFailureAsync(ex);
            }
            return null;
        }
    }

    public async Task UpdateAsync(TEntity model, TUserId requesterId, Func<Exception, Task>? onFailureAsync = null)
    {
        await using var _transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            model.ModifiedDate = DateTime.Now;
            model.ModifiedBy = requesterId;

            _dbSet.Update(model);
            await _context.SaveChangesAsync();

            await _transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            if (onFailureAsync != null)
            {
                await onFailureAsync(ex);
            }
        }

    }

    public async Task UpdateRangeAsync(IEnumerable<TEntity> models, TUserId requesterId, Func<Exception, Task>? onFailureAsync = null)
    {
        await using var _transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            foreach(var model in models)
            {
                model.ModifiedDate = DateTime.Now;
                model.ModifiedBy = requesterId;
            }

            _dbSet.UpdateRange(models);
            await _context.SaveChangesAsync();

            await _transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            if (onFailureAsync != null)
            {
                await onFailureAsync(ex);
            }
            await _transaction.RollbackAsync();
        }
    }

    public async Task DeleteAsync<TId>(TId id, TUserId requesterId, Func<Exception, Task>? onFailureAsync = null)
    {
        await using var _transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var item = await _dbSet.FindAsync(id);

            if (item != null)
            {
                item.IsActive = false;
                item.IsDeleted = true;
                item.DeletedDate = DateTime.Now;
                item.DeletedBy = requesterId;

                _dbSet.Update(item);

                await _context.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
        }
        catch (Exception ex)
        {
            if (onFailureAsync != null)
            {
                await onFailureAsync(ex);
            }
            await _transaction.RollbackAsync();
        }
    }

    public async Task DeleteRangeAsync<TId>(IEnumerable<TId> ids, TUserId requesterId, Func<Exception, Task>? onFailureAsync = null)
    {
        await using var _transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            foreach (var id in ids)
            {
                var item = await _dbSet.FindAsync(id);

                if (item != null)
                {
                    item.IsActive = false;
                    item.IsDeleted = true;
                    item.DeletedDate = DateTime.Now;
                    item.DeletedBy = requesterId;

                    _dbSet.Update(item);
                }
            }
        }
        catch (Exception ex)
        {
            if (onFailureAsync != null)
            {
                await onFailureAsync(ex);
            }
        }
    }
}

