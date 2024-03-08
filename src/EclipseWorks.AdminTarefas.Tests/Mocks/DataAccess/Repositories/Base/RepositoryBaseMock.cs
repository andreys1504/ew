using EclipseWorks.AdminTarefas.Base.DataAccessLayer;
using EclipseWorks.AdminTarefas.Base.DomainLayer;
using System.Linq.Expressions;

namespace EclipseWorks.AdminTarefas.Tests.Mocks.DataAccess.Repositories.Base;

public class RepositoryBaseMock<TEntity, TId> : IRepositoryBase<TEntity, TId> where TEntity : Entity<TId>
{
    private List<TEntity> _entities;

    public RepositoryBaseMock(List<TEntity> entities)
    {
        _entities = entities;
    }


    public Task CadastrarAsync(TEntity entity)
    {
        _entities.Add(entity);

        return Task.CompletedTask;
    }

    public Task CadastrarAsync(IEnumerable<TEntity> entities)
    {
        _entities.AddRange(entities);

        return Task.CompletedTask;
    }

    public void Editar(TEntity entity)
    {
        _entities = _entities.Where(e => e.Id2 != entity.Id2).ToList();
        _entities.Add(entity);
    }

    public void Editar(IEnumerable<TEntity> entities)
    {
        _entities = _entities.Where(e => entities.Select(ee => ee.Id2).Contains(e.Id2) == false).ToList();
        _entities.AddRange(entities);
    }

    public void Excluir(TEntity entity)
    {
        _entities = _entities.Where(e => e.Id2 != entity.Id2).ToList();
    }

    public void Excluir(IEnumerable<TEntity> entities)
    {
        _entities = _entities.Where(e => entities.Select(ee => ee.Id2).Contains(e.Id2) == false).ToList();
    }

    public Task<bool> ExistenteAsync(Expression<Func<TEntity, bool>> where)
    {
        IQueryable<TEntity> query = _entities.AsQueryable();

        return Task.FromResult(query.Where(where).Any());
    }

    public Task<int> QuantidadeAsync(Expression<Func<TEntity, bool>> where)
    {
        IQueryable<TEntity> query = _entities.AsQueryable();

        return Task.FromResult(query.Where(where).Count());
    }



    //BuscarAsync

    public Task<IList<TEntity>> BuscarAsync(Expression<Func<TEntity, object>> orderBy = null, bool asNoTracking = true, bool orderAsc = true)
    {
        IQueryable<TEntity> query = Query(
                where: null,
                orderBy: orderBy,
                asNoTracking: asNoTracking,
                orderAsc: orderAsc);

        return Task.FromResult((IList<TEntity>)query.ToList());
    }

    public Task<IList<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> orderBy = null, bool asNoTracking = true, bool orderAsc = true)
    {
        IQueryable<TEntity> query = Query(
                where: where,
                orderBy: orderBy,
                asNoTracking: asNoTracking,
                orderAsc: orderAsc);

        return Task.FromResult((IList<TEntity>)query.ToList());
    }

    public Task<IList<TResult>> BuscarAsync<TResult>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TResult>> select, Expression<Func<TEntity, object>> orderBy = null, bool asNoTracking = true, bool orderAsc = true) where TResult : class
    {
        IQueryable<TEntity> query = Query(
                where: where,
                orderBy: orderBy,
                asNoTracking: asNoTracking,
                orderAsc: orderAsc);

        return Task.FromResult((IList<TResult>)(query.Select(select).ToList()));
    }

    public Task<IList<TResult>> BuscarAsync<TResult>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TResult>> select, Expression<Func<TEntity, object>> orderBy = null, bool asNoTracking = true, bool orderAsc = true, int? take = null, params Expression<Func<TEntity, object>>[] includes) where TResult : class
    {
        IQueryable<TEntity> query = Query(
                where: where,
                orderBy: orderBy,
                orderAsc: orderAsc,
                asNoTracking: asNoTracking);

        if (take.HasValue)
            return Task.FromResult((IList<TResult>)(query.Select(select).Take(take.Value).ToList()));

        return Task.FromResult((IList<TResult>)(query.Select(select).ToList()));
    }



    //BuscarPrimeiroRegistroAsync

    public Task<TEntity> BuscarPrimeiroRegistroAsync(Expression<Func<TEntity, bool>> where, bool asNoTracking = true)
    {
        IQueryable<TEntity> query = Query(
            where: where,
            orderBy: null,
            asNoTracking: asNoTracking);

        return Task.FromResult(query.FirstOrDefault());
    }

    public Task<TResult> BuscarPrimeiroRegistroAsync<TResult>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TResult>> select, bool asNoTracking = true) where TResult : class
    {
        IQueryable<TEntity> query = Query(
            where: where,
            orderBy: null,
            asNoTracking: asNoTracking);

        return Task.FromResult(query.Select(select).FirstOrDefault());
    }

    public Task<TResult> BuscarPrimeiroRegistroAsync<TResult>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TResult>> select, bool asNoTracking = true, params Expression<Func<TEntity, object>>[] includes) where TResult : class
    {
        IQueryable<TEntity> query = Query(
            where: where,
            orderBy: null,
            asNoTracking: asNoTracking);

        return Task.FromResult(query.Select(select).FirstOrDefault());
    }


    //
    private IQueryable<TEntity> Query(
        Expression<Func<TEntity, bool>> where,
        Expression<Func<TEntity, object>> orderBy,
        bool asNoTracking = true,
        bool orderAsc = true)
    {
        IQueryable<TEntity> query = _entities.AsQueryable();

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
