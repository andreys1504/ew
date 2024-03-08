using EclipseWorks.AdminTarefas.Base.DomainLayer;
using System.Linq.Expressions;

namespace EclipseWorks.AdminTarefas.Base.DataAccessLayer;

public interface IRepositoryBase<TEntity, TId> where TEntity : Entity<TId>
{
    Task CadastrarAsync(TEntity entity);

    Task CadastrarAsync(IEnumerable<TEntity> entities);

    void Editar(TEntity entity);

    void Editar(IEnumerable<TEntity> entities);

    void Excluir(TEntity entity);

    void Excluir(IEnumerable<TEntity> entities);

    Task<bool> ExistenteAsync(Expression<Func<TEntity, bool>> where);

    Task<int> QuantidadeAsync(Expression<Func<TEntity, bool>> where);

    //BuscarAsync
    Task<IList<TEntity>> BuscarAsync(
        Expression<Func<TEntity, object>> orderBy = null,
        bool asNoTracking = true,
        bool orderAsc = true);

    Task<IList<TEntity>> BuscarAsync(
        Expression<Func<TEntity, bool>> where,
        Expression<Func<TEntity, object>> orderBy = null,
        bool asNoTracking = true,
        bool orderAsc = true);

    Task<IList<TResult>> BuscarAsync<TResult>(
        Expression<Func<TEntity, bool>> where,
        Expression<Func<TEntity, TResult>> select,
        Expression<Func<TEntity, object>> orderBy = null,
        bool asNoTracking = true,
        bool orderAsc = true) where TResult : class;

    Task<IList<TResult>> BuscarAsync<TResult>(
        Expression<Func<TEntity, bool>> where,
        Expression<Func<TEntity, TResult>> select,
        Expression<Func<TEntity, object>> orderBy = null,
        bool asNoTracking = true,
        bool orderAsc = true,
        int? take = null,
        params Expression<Func<TEntity, object>>[] includes) where TResult : class;

    //BuscarPrimeiroRegistroAsync
    Task<TEntity> BuscarPrimeiroRegistroAsync(
        Expression<Func<TEntity, bool>> where,
        bool asNoTracking = true);

    Task<TResult> BuscarPrimeiroRegistroAsync<TResult>(
        Expression<Func<TEntity, bool>> where,
        Expression<Func<TEntity, TResult>> select,
        bool asNoTracking = true) where TResult : class;

    Task<TResult> BuscarPrimeiroRegistroAsync<TResult>(
        Expression<Func<TEntity, bool>> where,
        Expression<Func<TEntity, TResult>> select,
        bool asNoTracking = true,
        params Expression<Func<TEntity, object>>[] includes) where TResult : class;
}
