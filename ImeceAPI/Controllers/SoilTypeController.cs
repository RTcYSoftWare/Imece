using BusinessLayer.Abstract;
using CoreLayer.Abstract;
using CoreLayer.Concrete;
using CoreLayer.Enums;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImeceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SoilTypeController : ControllerBase
    {
        private readonly ISoilTypeService _soilTypeService;


        public SoilTypeController(ISoilTypeService soilTypeService)
        {
            _soilTypeService = soilTypeService;
        }

        [HttpGet]
        [Route("get-soil-types")]
        public async Task<IResultModel> GetSoilTypes()
        {
            var soilTypes = await _soilTypeService.GetItems();

            return new ResultModel((int)ResultModelEnum.Transaction_Success, ResultModelEnum.Transaction_Success.ToString(), soilTypes);
        }

        [HttpGet]
        [Route("get-soil-type")]
        public async Task<IResultModel> GetSoilType(int id)
        {
            IResultModel resultModel;

            if (id > 0)
            {
                var soilType = await _soilTypeService.GetItem(id);

                if (soilType != null)
                {
                    resultModel = new ResultModel((int)ResultModelEnum.Transaction_Success, ResultModelEnum.Transaction_Success.ToString(), soilType);
                }

                else
                {
                    resultModel = new ResultModel((int)ResultModelEnum.Soil_Type_Not_Found, ResultModelEnum.Soil_Type_Not_Found.ToString(), null);
                }
            }

            else
            {
                resultModel = new ResultModel((int)ResultModelEnum.Model_Invalid, ResultModelEnum.Model_Invalid.ToString(), null);
            }

            return resultModel;
        }

        [HttpPost]
        [Route("create-or-update-soil-type")]
        public async Task<IResultModel> CreateOrUpdateSoilType(int id, string name, bool isActive = true)
        {
            IResultModel resultModel;

            if (id >= 0 && name != null)
            {
                if (id == 0)
                {
                    SoilType soilType = new SoilType();

                    soilType.Name = name;
                    soilType.IsActive = isActive;                    

                    await _soilTypeService.CreateItem(soilType);

                    if (soilType.Id > 0)
                    {
                        resultModel = new ResultModel((int)ResultModelEnum.Soil_Type_Created, ResultModelEnum.Soil_Type_Created.ToString(), soilType);
                    }

                    else
                    {
                        resultModel = new ResultModel((int)ResultModelEnum.Transaction_Failed, ResultModelEnum.Transaction_Failed.ToString(), null);
                    }
                }

                else
                {
                    var soilType = await _soilTypeService.GetItem(id);

                    if (soilType != null)
                    {
                        soilType.Name = name;
                        soilType.IsActive = isActive;

                        await _soilTypeService.UpdateItem(soilType);

                        resultModel = new ResultModel((int)ResultModelEnum.Soil_Type_Updated, ResultModelEnum.Soil_Type_Updated.ToString(), soilType);
                    }

                    else
                    {
                        resultModel = new ResultModel((int)ResultModelEnum.Soil_Type_Not_Found, ResultModelEnum.Soil_Type_Not_Found.ToString(), null);
                    }
                }
            }

            else
            {
                resultModel = new ResultModel((int)ResultModelEnum.Model_Invalid, ResultModelEnum.Model_Invalid.ToString(), null);
            }

            return resultModel;
        }
    }
}
