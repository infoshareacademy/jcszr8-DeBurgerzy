using System.Linq.Expressions;

namespace ParcelDistributionCenter.Model.Repositories
{
    public interface IRepository<T>
    {
        void Delete(T entity);

        T Get(string id, Expression<Func<T, object>>? include = null);

        IEnumerable<T> GetAll(Expression<Func<T, object>>? include = null);

        void Insert(T entity);

        void Update(T entity);
    }
}