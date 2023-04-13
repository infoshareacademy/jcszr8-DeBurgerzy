using Microsoft.EntityFrameworkCore;
using ParcelDistributionCenter.Model.Context;
using ParcelDistributionCenter.Model.Models.BaseEntity;

namespace ParcelDistributionCenter.Model.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly ParcelDistributionCenterContext _context;
        private readonly DbSet<T> _entities;

        public Repository(ParcelDistributionCenterContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public void Delete(T entity)
        {
            if (entity != null)
            {
                _entities.Remove(entity);
                _context.SaveChanges();
            }
        }

        public T Get(string id) => _entities.SingleOrDefault(e => e.Id == id);

        public IEnumerable<T> GetAll() => _entities;

        public void Insert(T entity)
        {
            if (entity != null)
            {
                _entities.Add(entity);
                _context.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            if (entity != null)
            {
                _entities.Update(entity);
                _context.SaveChanges();
            }
        }
    }
}