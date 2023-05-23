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
    public class GrowingAreaController : ControllerBase
    {
        private readonly IGrowingAreaService _growingAreaService;


        public GrowingAreaController(IGrowingAreaService growingAreaService)
        {
            _growingAreaService = growingAreaService;
        }

        [HttpGet]
        [Route("get-growing-areas")]
        public async Task<IResultModel> GetGrowingAreas()
        {
            var growingAreas = await _growingAreaService.GetItems();

            return new ResultModel((int)ResultModelEnum.Transaction_Success, ResultModelEnum.Transaction_Success.ToString(), growingAreas);
        }

        [HttpGet]
        [Route("get-growing-area")]
        public async Task<IResultModel> GetGrowingArea(int id)
        {
            IResultModel resultModel;

            if (id > 0)
            {
                var growingArea = await _growingAreaService.GetItem(id);

                if (growingArea != null)
                {
                    resultModel = new ResultModel((int)ResultModelEnum.Transaction_Success, ResultModelEnum.Transaction_Success.ToString(), growingArea);
                }

                else
                {
                    resultModel = new ResultModel((int)ResultModelEnum.Growing_Area_Not_Found, ResultModelEnum.Growing_Area_Not_Found.ToString(), null);
                }
            }

            else
            {
                resultModel = new ResultModel((int)ResultModelEnum.Model_Invalid, ResultModelEnum.Model_Invalid.ToString(), null);
            }

            return resultModel;
        }

        [HttpPost]
        [Route("create-or-update-growing-area")]
        public async Task<IResultModel> CreateOrUpdateGrowingArea(int id, string name, bool isActive = true)
        {
            IResultModel resultModel;

            if (id >= 0 && name != null)
            {
                if (id == 0)
                {
                    GrowingArea growingArea = new GrowingArea();

                    growingArea.Name = name;
                    growingArea.IsActive = isActive;                    

                    await _growingAreaService.CreateItem(growingArea);

                    if (growingArea.Id > 0)
                    {
                        resultModel = new ResultModel((int)ResultModelEnum.Growing_Area_Created, ResultModelEnum.Growing_Area_Created.ToString(), growingArea);
                    }

                    else
                    {
                        resultModel = new ResultModel((int)ResultModelEnum.Transaction_Failed, ResultModelEnum.Transaction_Failed.ToString(), null);
                    }
                }

                else
                {
                    var growingArea = await _growingAreaService.GetItem(id);

                    if (growingArea != null)
                    {
                        growingArea.Name = name;
                        growingArea.IsActive = isActive;

                        await _growingAreaService.UpdateItem(growingArea);

                        resultModel = new ResultModel((int)ResultModelEnum.Growing_Area_Updated, ResultModelEnum.Growing_Area_Updated.ToString(), growingArea);
                    }

                    else
                    {
                        resultModel = new ResultModel((int)ResultModelEnum.Growing_Area_Not_Found, ResultModelEnum.Growing_Area_Not_Found.ToString(), null);
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
