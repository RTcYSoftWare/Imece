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
    public class IrrigationTypeController : ControllerBase
    {
        private readonly IIrrigationTypeService _irrigationTypeService;


        public IrrigationTypeController(IIrrigationTypeService irrigationTypeService)
        {
            _irrigationTypeService = irrigationTypeService;
        }

        [HttpGet]
        [Route("get-irrigation-types")]
        public async Task<IResultModel> GetIrrigationTypes()
        {
            var irrigationTypes = await _irrigationTypeService.GetItems();

            return new ResultModel((int)ResultModelEnum.Transaction_Success, ResultModelEnum.Transaction_Success.ToString(), irrigationTypes);
        }

        [HttpGet]
        [Route("get-irrigation-type")]
        public async Task<IResultModel> GetIrrigationType(int id)
        {
            IResultModel resultModel;

            if (id > 0)
            {
                var irrigationType = await _irrigationTypeService.GetItem(id);

                if (irrigationType != null)
                {
                    resultModel = new ResultModel((int)ResultModelEnum.Transaction_Success, ResultModelEnum.Transaction_Success.ToString(), irrigationType);
                }

                else
                {
                    resultModel = new ResultModel((int)ResultModelEnum.Irrigation_Type_Not_Found, ResultModelEnum.Irrigation_Type_Not_Found.ToString(), null);
                }
            }

            else
            {
                resultModel = new ResultModel((int)ResultModelEnum.Model_Invalid, ResultModelEnum.Model_Invalid.ToString(), null);
            }

            return resultModel;
        }

        [HttpPost]
        [Route("create-or-update-irrigation-type")]
        public async Task<IResultModel> CreateOrUpdateIrrigationType(int id, string name, bool isActive = true)
        {
            IResultModel resultModel;

            if (id >= 0 && name != null)
            {
                if (id == 0)
                {
                    IrrigationType irrigationType = new IrrigationType();
                    
                    irrigationType.Name = name;
                    irrigationType.IsActive = isActive;                    

                    await _irrigationTypeService.CreateItem(irrigationType);

                    if (irrigationType.Id > 0)
                    {
                        resultModel = new ResultModel((int)ResultModelEnum.Irrigation_Type_Created, ResultModelEnum.Irrigation_Type_Created.ToString(), irrigationType);
                    }

                    else
                    {
                        resultModel = new ResultModel((int)ResultModelEnum.Transaction_Failed, ResultModelEnum.Transaction_Failed.ToString(), null);
                    }
                }

                else
                {
                    var irrigationType = await _irrigationTypeService.GetItem(id);

                    if (irrigationType != null)
                    {
                        irrigationType.Name = name;
                        irrigationType.IsActive = isActive;

                        await _irrigationTypeService.UpdateItem(irrigationType);

                        resultModel = new ResultModel((int)ResultModelEnum.Irrigation_Type_Updated, ResultModelEnum.Irrigation_Type_Updated.ToString(), irrigationType);
                    }

                    else
                    {
                        resultModel = new ResultModel((int)ResultModelEnum.Irrigation_Type_Not_Found, ResultModelEnum.Irrigation_Type_Not_Found.ToString(), null);
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
