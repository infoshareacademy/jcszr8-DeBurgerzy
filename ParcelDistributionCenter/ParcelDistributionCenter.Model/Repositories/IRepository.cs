namespace ParcelDistributionCenter.Model.Repositories
{
    public interface IRepository<T>
    {
        void Delete(T entity);

        T Get(string id);

        IEnumerable<T> GetAll();

        void Insert(T entity);

        void Update(T entity);
    }
}