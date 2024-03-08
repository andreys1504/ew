using EclipseWorks.AdminTarefas.Base.DataAccessLayer;
using EclipseWorks.AdminTarefas.Base.DomainLayer;
using EclipseWorks.AdminTarefas.DataAccess.EfContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EclipseWorks.AdminTarefas.DataAccess.Repositories.Base;

public abstract class RepositoryBase<TEntity, TId> : IRepositoryBase<TEntity, TId> where TEntity : Entity<TId>
{
    private readonly AppDbContext _context;

    public RepositoryBase(AppDbContext context)
    {
        _context = context;
    }

    public async Task CadastrarAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
    }

    public async Task CadastrarAsync(IEnumerable<TEntity> entities)
    {
        await _context.Set<TEntity>().AddRangeAsync(entities);
    }

    public void Editar(TEntity entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
        {
            _context.Set<TEntity>().Update(entity);
        }
    }

    public void Editar(IEnumerable<TEntity> entities)
    {
        IEnumerable<TEntity> detachedEntities =
            entities.Where(entity =>
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                    return true;

                return false;
            });

        _context.Set<TEntity>().UpdateRange(detachedEntities);
    }

    public void Excluir(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public void Excluir(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().RemoveRange(entities);
    }

    public async Task<bool> ExistenteAsync(Expression<Func<TEntity, bool>> where)
    {
        return await _context.Set<TEntity>().AsNoTracking().AnyAsync(where);
    }

    public async Task<int> QuantidadeAsync(Expression<Func<TEntity, bool>> where)
    {
        return await _context.Set<TEntity>().CountAsync(predicate: where);
    }

    //Buscar
    public async Task<IList<TEntity>> BuscarAsync(
            Expression<Func<TEntity, object>> orderBy = null,
            bool asNoTracking = true,
            bool orderAsc = true)
    {
        IQueryable<TEntity> query = Query(
            where: null,
            orderBy: orderBy,
            asNoTracking: asNoTracking,
            orderAsc: orderAsc);

        return await query.ToListAsync();
    }

    public async Task<IList<TEntity>> BuscarAsync(
            Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, object>> orderBy = null,
            bool asNoTracking = true,
            bool orderAsc = true)
    {
        IQueryable<TEntity> query = Query(
            where: where,
            orderBy: orderBy,
            asNoTracking: asNoTracking,
            orderAsc: orderAsc);

        return await query.ToListAsync();
    }

    public async Task<IList<TResult>> BuscarAsync<TResult>(
            Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, TResult>> select,
            Expression<Func<TEntity, object>> orderBy = null,
            bool asNoTracking = true,
            bool orderAsc = true) where TResult : class
    {
        IQueryable<TEntity> query = Query(
            where: where,
            orderBy: orderBy,
            asNoTracking: asNoTracking,
            orderAsc: orderAsc);

        return await query.Select(select).ToListAsync();
    }

    public async Task<IList<TResult>> BuscarAsync<TResult>(
            Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, TResult>> select,
            Expression<Func<TEntity, object>> orderBy = null,
            bool asNoTracking = true,
            bool orderAsc = true,
            params Expression<Func<TEntity, object>>[] includes) where TResult : class
    {
        IQueryable<TEntity> query = Query(
            where: where,
            orderBy: orderBy,
            asNoTracking: asNoTracking,
            orderAsc: orderAsc);

        if (includes != null && includes.Length > 0)
            query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

        return await query.Select(select).ToListAsync();
    }

    public async Task<IList<TResult>> BuscarAsync<TResult>(
            Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, TResult>> select,
            Expression<Func<TEntity, object>> orderBy = null,
            bool asNoTracking = true,
            bool orderAsc = true,
            int? take = null,
            params Expression<Func<TEntity, object>>[] includes) where TResult : class
    {
        IQueryable<TEntity> query = Query(
            where: where,
            orderBy: orderBy,
            orderAsc: orderAsc,
            asNoTracking: asNoTracking);

        if (includes != null && includes.Length > 0)
            query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

        if (take.HasValue)
            return await query.Select(select).Take(take.Value).ToListAsync();

        return await query.Select(select).ToListAsync();
    }

    //BuscarPrimeiroRegistro
    public async Task<TEntity> BuscarPrimeiroRegistroAsync(
            Expression<Func<TEntity, bool>> where,
            bool asNoTracking = true)
    {
        IQueryable<TEntity> query = Query(
            where: where,
            orderBy: null,
            asNoTracking: asNoTracking);

        return await query.FirstOrDefaultAsync();
    }

    public async Task<TResult> BuscarPrimeiroRegistroAsync<TResult>(
            Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, TResult>> select,
            bool asNoTracking = true) where TResult : class
    {
        IQueryable<TEntity> query = Query(
            where: where,
            orderBy: null,
            asNoTracking: asNoTracking);

        return await query.Select(select).FirstOrDefaultAsync();
    }

    public async Task<TResult> BuscarPrimeiroRegistroAsync<TResult>(
            Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, TResult>> select,
            bool asNoTracking = true,
            params Expression<Func<TEntity, object>>[] includes) where TResult : class
    {
        IQueryable<TEntity> query = Query(
            where: where,
            orderBy: null,
            asNoTracking: asNoTracking);

        if (includes != null && includes.Length > 0)
            query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

        return await query.Select(select).FirstOrDefaultAsync();
    }


    //
    private IQueryable<TEntity> Query(
        Expression<Func<TEntity, bool>> where,
        Expression<Func<TEntity, object>> orderBy,
        bool asNoTracking = true,
        bool orderAsc = true)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>().AsQueryable();

        if (asNoTracking)
            query = query.AsNoTracking();

        if (where != null)
            query = query.Where(where);

        if (orderBy != null)
        {
            if (orderAsc)
                query = query.OrderBy(orderBy);
            else
                query = query.OrderByDescending(orderBy);
        }

        return query;
    }
}
