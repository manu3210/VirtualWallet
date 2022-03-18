using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualWallet.Interfaces;
using VirtualWallet.Models;

namespace VirtualWallet.Repository
{
    public abstract class Repository<T> : IDataProcessing<T> where T : BaseModel
    {
        protected readonly WalletContext _context;

        public Repository(WalletContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T element)
        {
            _context.Set<T>().Add(element);
            await _context.SaveChangesAsync();

            return element;
        }

        public async Task DeleteAsync(int id)
        {
            var toDelete = await GetAsync(id);
            _context.Set<T>().Remove(toDelete);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> UpdateAsync(int id, T element)
        {
            var toUpdate = await GetAsync(id);

            if (toUpdate == null)
                return null;

            UpdateData(toUpdate, element);

            await _context.SaveChangesAsync();

            return element;
        }

        protected abstract void UpdateData(T toUpdate, T element);
    }
}
