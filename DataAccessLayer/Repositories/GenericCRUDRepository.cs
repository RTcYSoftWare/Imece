using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class GenericCRUDRepository<T> : IGenericCRUDDal<T> where T : class
    {
        public async Task<T> CreateItem(T item)
        {
            using (ImeceDBContext context = new ImeceDBContext())
            {
                context.Add(item);
                await context.SaveChangesAsync();
            }
            return item;
        }

        public Task<T> DeleteItem(T item)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetItem(int id)
        {
            using (ImeceDBContext context = new ImeceDBContext())
            {
                return await context.Set<T>().FindAsync(id);
            }
        }

        public async Task<List<T>> GetItems()
        {
            using (ImeceDBContext context = new ImeceDBContext())
            {
                return await context.Set<T>().ToListAsync();
            }
        }

        public async Task<T> UpdateItem(T item)
        {
            using (ImeceDBContext context = new ImeceDBContext())
            {
                context.Update(item);
                await context.SaveChangesAsync();
            }

            return item;
        }
    }
}
