using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IRepositoryEF<T> where T : class
    {
        Task<bool> Delete(T entity);
        Task<int> Insert(T entity);
        Task<bool> Update(T entity);
    }
}
