using Stock.Core.Entities;

namespace Stock.Core.Repository {

    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(string id);
        Task Add(TEntity entity);
        Task AddMany(List<TEntity> entity);
        Task Update(TEntity entity);
        Task Delete(string id);
    }

}

