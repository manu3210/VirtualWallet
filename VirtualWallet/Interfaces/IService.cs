using System.Collections.Generic;
using System.Threading.Tasks;

namespace VirtualWallet.Interfaces
{
    public interface IService<T>
    {
        Task<T> Create(T element);
        Task<T> Get(int id);
        Task<T> Update(int id, T element);
        Task Delete(int id);
        Task<List<T>> GetAll();
    }
}
