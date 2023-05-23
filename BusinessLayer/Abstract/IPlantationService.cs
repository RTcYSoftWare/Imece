using CoreLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPlantationService : IGenericService<Plantation>
    {
        public Task<IResultModel> GetPlantationsByUserId(bool isActive = true);
    }
}
