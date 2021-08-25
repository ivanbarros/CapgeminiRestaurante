using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capgemini.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : class
    {
        Task<IEnumerable<T>> Get(T entity);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task GetById(int id);
        Task GetByName(string name);


    }
}