using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IPlantationDal : IGenericCRUDDal<Plantation>
    {
        public Task<List<Plantation>> GetPlantationsByUserId(int userId, bool isActive = true);
    }
}
