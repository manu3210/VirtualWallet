using System.Collections.Generic;
using System.Linq;
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

        public T Create(T element)
        {
            _context.Set<T>().Add(element);
            _context.SaveChanges();

            return element;
        }

        public void Delete(int id)
        {
            _context.Set<T>().Remove(Get(id));
            _context.SaveChanges();
        }

        public virtual T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T Update(int id, T element)
        {
            var toUpdate = Get(id);

            if (toUpdate == null)
                return null;

            UpdateData(toUpdate, element);

            _context.SaveChanges();

            return element;
        }

        protected abstract void UpdateData(T toUpdate, T element);
    }
}
