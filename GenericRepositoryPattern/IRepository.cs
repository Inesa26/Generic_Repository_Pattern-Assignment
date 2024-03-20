using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryPattern
{
    public interface IRepository<T> where T : Entity
    {
        T Get(Guid id);
        List<T> GetAll();
        void Delete(Guid id);
        void Add(T entity);
        void Update(Guid id, T entity);
    }
}
