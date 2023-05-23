using BusinessLayer.Abstract;
using CoreLayer.Abstract;
using CoreLayer.Concrete;
using CoreLayer.Enums;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PlantationManager : IPlantationService
    {
        private readonly IPlantationDal _plantationDal;
        private readonly IAuthenticationHelper _authenticationHelper;

        public PlantationManager(IPlantationDal plantationDal, IAuthenticationHelper authenticationHelper)
        {
            _plantationDal = plantationDal;
            _authenticationHelper = authenticationHelper;
        }

        public async Task<Plantation> CreateItem(Plantation item)
        {
            item.CreatedAt = DateTime.Now;

            return await _plantationDal.CreateItem(item);
        }

        public async Task<Plantation> DeleteItem(Plantation item)
        {
            return await _plantationDal.DeleteItem(item);
        }

        public async Task<Plantation> GetItem(int id)
        {
            return await _plantationDal.GetItem(id);
        }

        public async Task<List<Plantation>> GetItems()
        {
            var result = await _plantationDal.GetItems();

            var select = result.Select(x => new
            {
                x.Id,
                x.Name,
                x.Latitude,
                x.Longitude,
                x.Altitude,
                product = x.Product.Name,
                productType = x.ProductType.Name,
                growingArea = x.GrowingArea.Name,
                x.SowingPlantingAt,
                x.HarvestAt,
                x.Decare,
                soilType = x.SoilType.Name,
                irrigationType = x.IrrigationType.Name,
                x.Ada,
                x.Parcel,
            });

            return result;
        }

        public async Task<Plantation> UpdateItem(Plantation item)
        {
            item.UpdatedAt = DateTime.Now;

            return await _plantationDal.UpdateItem(item);
        }

        public async Task<IResultModel> GetPlantationsByUserId(bool isActive = true)
        {
            IResultModel resultModel;

            var currentUser = _authenticationHelper.GetCurrentUser();

            if (currentUser != null)
            {
                var plantations = await _plantationDal.GetPlantationsByUserId(currentUser.Id, isActive);

                var select = plantations.Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Latitude,
                    x.Longitude,
                    x.Altitude,
                    product = x.Product.Name,
                    productType = x.ProductType.Name,
                    growingArea = x.GrowingArea.Name,
                    x.SowingPlantingAt,
                    x.HarvestAt,
                    x.Decare,
                    soilType = x.SoilType.Name,
                    irrigationType = x.IrrigationType.Name,
                    x.Ada,
                    x.Parcel,
                });

                resultModel = new ResultModel((int)ResultModelEnum.Transaction_Success, ResultModelEnum.Transaction_Success.ToString(), select);
            }

            else
            {
                resultModel = new ResultModel((int)ResultModelEnum.User_Not_Found, ResultModelEnum.User_Not_Found.ToString(), null);
            }

            return resultModel;
        }
    }
}
