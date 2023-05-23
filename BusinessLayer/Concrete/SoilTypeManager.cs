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
    public class SoilTypeManager : ISoilTypeService
    {
        private readonly ISoilTypeDal _soilTypeDal;


        public SoilTypeManager(ISoilTypeDal soilTypeDal)
        {
            _soilTypeDal = soilTypeDal;
        }

        public async Task<SoilType> CreateItem(SoilType item)
        {
            item.CreatedAt = DateTime.Now;            

            return await _soilTypeDal.CreateItem(item);
        }

        public async Task<SoilType> DeleteItem(SoilType item)
        {
            return await _soilTypeDal.DeleteItem(item);
        }

        public async Task<SoilType> GetItem(int id)
        {
            return await _soilTypeDal.GetItem(id);
        }

        public async Task<List<SoilType>> GetItems()
        {
            return await _soilTypeDal.GetItems();
        }

        public async Task<SoilType> UpdateItem(SoilType item)
        {
            item.UpdatedAt = DateTime.Now;

            return await _soilTypeDal.UpdateItem(item);
        }
    }
}
