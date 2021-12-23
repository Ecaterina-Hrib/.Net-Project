using System.Collections.Generic;

namespace HousePricePrediction.Data
{
    public interface IRepository<T>
    {
        T GetById(System.Type id);
        List<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}