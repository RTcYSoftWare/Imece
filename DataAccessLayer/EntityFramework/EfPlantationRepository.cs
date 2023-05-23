using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfPlantationRepository : GenericCRUDRepository<Plantation>, IPlantationDal
    {
        private readonly ImeceDBContext _context;

        public EfPlantationRepository(ImeceDBContext context)
        {
            _context = context;
        }

        public async Task<List<Plantation>> GetPlantationsByUserId(int userId, bool isActive = true)
        {
            return await _context.Plantations.Where(x => x.UserId == userId && x.IsActive == isActive)
                .Include(x => x.Product)
                .Include(x => x.ProductType)
                .Include(x => x.GrowingArea)
                .Include(x => x.SoilType)
                .Include(x => x.IrrigationType)
                .ToListAsync();
        }
    }
}
