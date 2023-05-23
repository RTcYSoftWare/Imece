using BusinessLayer.Abstract;
using CoreLayer.Abstract;
using CoreLayer.Concrete;
using CoreLayer.Enums;
using EntityLayer.Concrete;
using EntityLayer.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImeceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlantationController : ControllerBase
    {
        private readonly IPlantationService _plantationService;
        private readonly IAuthenticationHelper _authenticationHelper;


        public PlantationController(IPlantationService plantationService, IAuthenticationHelper authenticationHelper)
        {
            _plantationService = plantationService;
            _authenticationHelper = authenticationHelper;
        }

        [HttpGet]
        [Route("get-plantations")]
        public async Task<IResultModel> GetPlantations()
        {
            var plantations = await _plantationService.GetItems();

            return new ResultModel((int)ResultModelEnum.Transaction_Success, ResultModelEnum.Transaction_Success.ToString(), plantations);
        }

        [HttpGet]
        [Route("get-plantation")]
        public async Task<IResultModel> GetPlantation(int id)
        {
            IResultModel resultModel;

            if (id > 0)
            {
                var plantation = await _plantationService.GetItem(id);

                if (plantation != null)
                {
                    resultModel = new ResultModel((int)ResultModelEnum.Transaction_Success, ResultModelEnum.Transaction_Success.ToString(), plantation);
                }

                else
                {
                    resultModel = new ResultModel((int)ResultModelEnum.Plantation_Not_Found, ResultModelEnum.Plantation_Not_Found.ToString(), null);
                }
            }

            else
            {
                resultModel = new ResultModel((int)ResultModelEnum.Model_Invalid, ResultModelEnum.Model_Invalid.ToString(), null);
            }

            return resultModel;
        }

        [HttpPost]
        [Route("create-or-update-plantation")]
        public async Task<IResultModel> CreateOrUpdatePlantation(PlantationCreateOrUpdateDto plantationCreateOrUpdateDto)
        {
            IResultModel resultModel;

            if (ModelState.IsValid)
            {
                var currentUser = _authenticationHelper.GetCurrentUser();

                if (currentUser != null)
                {
                    if (plantationCreateOrUpdateDto.Id == 0)
                    {
                        Plantation plantation = new Plantation();

                        plantation.UserId = currentUser.Id;
                        plantation.Name = plantationCreateOrUpdateDto.Name;
                        plantation.Latitude = plantationCreateOrUpdateDto.Latitude;
                        plantation.Longitude = plantationCreateOrUpdateDto.Longitude;
                        plantation.Altitude = plantationCreateOrUpdateDto.Altitude;
                        plantation.ProductId = plantationCreateOrUpdateDto.ProductId;
                        plantation.ProductTypeId = plantationCreateOrUpdateDto.ProductTypeId;
                        plantation.GrowingAreaId = plantationCreateOrUpdateDto.GrowingAreaId;
                        plantation.SowingPlantingAt = plantationCreateOrUpdateDto.SowingPlantingAt;
                        plantation.HarvestAt = plantationCreateOrUpdateDto.HarvestAt;
                        plantation.Decare = plantationCreateOrUpdateDto.Decare;
                        plantation.SoilTypeId = plantationCreateOrUpdateDto.SoilTypeId;
                        plantation.IrrigationTypeId = plantationCreateOrUpdateDto.IrrigationTypeId;

                        await _plantationService.CreateItem(plantation);

                        if (plantation.Id > 0)
                        {
                            resultModel = new ResultModel((int)ResultModelEnum.Plantation_Created, ResultModelEnum.Plantation_Created.ToString(), plantation);
                        }

                        else
                        {
                            resultModel = new ResultModel((int)ResultModelEnum.Transaction_Failed, ResultModelEnum.Transaction_Failed.ToString(), null);
                        }
                    }

                    else
                    {
                        var plantation = await _plantationService.GetItem(plantationCreateOrUpdateDto.Id);

                        if (plantation != null)
                        {
                            plantation.UserId = currentUser.Id;
                            plantation.Name = plantationCreateOrUpdateDto.Name;
                            plantation.Latitude = plantationCreateOrUpdateDto.Latitude;
                            plantation.Longitude = plantationCreateOrUpdateDto.Longitude;
                            plantation.Altitude = plantationCreateOrUpdateDto.Altitude;
                            plantation.ProductId = plantationCreateOrUpdateDto.ProductId;
                            plantation.ProductTypeId = plantationCreateOrUpdateDto.ProductTypeId;
                            plantation.GrowingAreaId = plantationCreateOrUpdateDto.GrowingAreaId;
                            plantation.SowingPlantingAt = plantationCreateOrUpdateDto.SowingPlantingAt;
                            plantation.HarvestAt = plantationCreateOrUpdateDto.HarvestAt;
                            plantation.Decare = plantationCreateOrUpdateDto.Decare;
                            plantation.SoilTypeId = plantationCreateOrUpdateDto.SoilTypeId;
                            plantation.IrrigationTypeId = plantationCreateOrUpdateDto.IrrigationTypeId;

                            await _plantationService.UpdateItem(plantation);

                            resultModel = new ResultModel((int)ResultModelEnum.Plantation_Updated, ResultModelEnum.Plantation_Updated.ToString(), plantation);
                        }

                        else
                        {
                            resultModel = new ResultModel((int)ResultModelEnum.Plantation_Not_Found, ResultModelEnum.Plantation_Not_Found.ToString(), null);
                        }
                    }
                }

                else
                {
                    resultModel = new ResultModel((int)ResultModelEnum.User_Not_Found, ResultModelEnum.User_Not_Found.ToString(), null);
                }
            }

            else
            {
                resultModel = new ResultModel((int)ResultModelEnum.Model_Invalid, ResultModelEnum.Model_Invalid.ToString(), null);
            }

            return resultModel;
        }

        [HttpGet]
        [Route("get-plantations-by-user-id")]
        public async Task<IResultModel> GetPlantationsByUserId(bool isActive = true)
        {
            IResultModel resultModel;

            resultModel = await _plantationService.GetPlantationsByUserId(isActive);

            return resultModel;
        }
    }
}
