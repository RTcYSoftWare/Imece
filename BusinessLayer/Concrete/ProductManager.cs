using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;


        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public async Task<Product> CreateItem(Product item)
        {
            item.CreatedAt = DateTime.Now;            

            return await _productDal.CreateItem(item);
        }

        public async Task<Product> DeleteItem(Product item)
        {
            return await _productDal.DeleteItem(item);
        }

        public async Task<Product> GetItem(int id)
        {
            return await _productDal.GetItem(id);
        }

        public async Task<List<Product>> GetItems()
        {
            return await _productDal.GetItems();
        }

        public async Task<Product> UpdateItem(Product item)
        {
            item.UpdatedAt = DateTime.Now;

            return await _productDal.UpdateItem(item);
        }
    }
}
