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
    public class GrowingAreaManager : IGrowingAreaService
    {
        private readonly IGrowingAreaDal _growingAreaDal;


        public GrowingAreaManager(IGrowingAreaDal growingAreaDal)
        {
            _growingAreaDal = growingAreaDal;
        }

        public async Task<GrowingArea> CreateItem(GrowingArea item)
        {
            item.CreatedAt = DateTime.Now;            

            return await _growingAreaDal.CreateItem(item);
        }

        public async Task<GrowingArea> DeleteItem(GrowingArea item)
        {
            return await _growingAreaDal.DeleteItem(item);
        }

        public async Task<GrowingArea> GetItem(int id)
        {
            return await _growingAreaDal.GetItem(id);
        }

        public async Task<List<GrowingArea>> GetItems()
        {
            return await _growingAreaDal.GetItems();
        }

        public async Task<GrowingArea> UpdateItem(GrowingArea item)
        {
            item.UpdatedAt = DateTime.Now;

            return await _growingAreaDal.UpdateItem(item);
        }
    }
}
