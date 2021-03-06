using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IBaseRepository<T> where T: class
    {
        Task<T> Add(T entity);

        Task<T> Update(T entity);

        Task Delete(T entity);

        Task<IEnumerable<T>> ListAll();
    }
}
