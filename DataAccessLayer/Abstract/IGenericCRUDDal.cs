using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericCRUDDal<T> where T : class
    {
        public Task<T> CreateItem(T item);
        public Task<T> UpdateItem(T item);
        public Task<T> DeleteItem(T item);
        public Task<T> GetItem(int id);
        public Task<List<T>> GetItems();
    }
}
