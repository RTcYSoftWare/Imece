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
    public class IrrigationTypeManager : IIrrigationTypeService
    {
        private readonly IIrrigationTypeDal _irrigationTypeDal;


        public IrrigationTypeManager(IIrrigationTypeDal irrigationTypeDal)
        {
            _irrigationTypeDal = irrigationTypeDal;
        }

        public async Task<IrrigationType> CreateItem(IrrigationType item)
        {
            item.CreatedAt = DateTime.Now;            

            return await _irrigationTypeDal.CreateItem(item);
        }

        public async Task<IrrigationType> DeleteItem(IrrigationType item)
        {
            return await _irrigationTypeDal.DeleteItem(item);
        }

        public async Task<IrrigationType> GetItem(int id)
        {
            return await _irrigationTypeDal.GetItem(id);
        }

        public async Task<List<IrrigationType>> GetItems()
        {
            return await _irrigationTypeDal.GetItems();
        }

        public async Task<IrrigationType> UpdateItem(IrrigationType item)
        {
            item.UpdatedAt = DateTime.Now;

            return await _irrigationTypeDal.UpdateItem(item);
        }
    }
}
