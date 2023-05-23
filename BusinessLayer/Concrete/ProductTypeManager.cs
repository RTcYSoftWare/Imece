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
    public class ProductTypeManager : IProductTypeService
    {
        private readonly IProductTypeDal _productTypeDal;


        public ProductTypeManager(IProductTypeDal productTypeDal)
        {
            _productTypeDal = productTypeDal;
        }

        public async Task<ProductType> CreateItem(ProductType item)
        {
            item.CreatedAt = DateTime.Now;            

            return await _productTypeDal.CreateItem(item);
        }

        public async Task<ProductType> DeleteItem(ProductType item)
        {
            return await _productTypeDal.DeleteItem(item);
        }

        public async Task<ProductType> GetItem(int id)
        {
            return await _productTypeDal.GetItem(id);
        }

        public async Task<List<ProductType>> GetItems()
        {
            return await _productTypeDal.GetItems();
        }

        public async Task<ProductType> UpdateItem(ProductType item)
        {
            item.UpdatedAt = DateTime.Now;

            return await _productTypeDal.UpdateItem(item);
        }
    }
}
