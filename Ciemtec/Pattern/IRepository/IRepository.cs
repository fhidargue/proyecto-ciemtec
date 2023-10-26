using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciemtec_FND.Pattern.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(string url, int id);

        Task<IEnumerable<T>> GetAllAsync(string url);

        Task<bool> CreateAsync(string url, T obj);

        Task<bool> UpdateAsync(string url, T obj, int id);

        Task<bool> DeleteAsync(string url, int id);
    }
}
