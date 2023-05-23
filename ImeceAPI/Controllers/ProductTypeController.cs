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
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;


        public ProductTypeController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        [HttpGet]
        [Route("get-product-types")]
        public async Task<IResultModel> GetProductTypes()
        {
            var productTypes = await _productTypeService.GetItems();

            return new ResultModel((int)ResultModelEnum.Transaction_Success, ResultModelEnum.Transaction_Success.ToString(), productTypes);
        }

        [HttpGet]
        [Route("get-product-type")]
        public async Task<IResultModel> GetProductType(int id)
        {
            IResultModel resultModel;

            if (id > 0)
            {
                var productType = await _productTypeService.GetItem(id);

                if (productType != null)
                {
                    resultModel = new ResultModel((int)ResultModelEnum.Transaction_Success, ResultModelEnum.Transaction_Success.ToString(), productType);
                }

                else
                {
                    resultModel = new ResultModel((int)ResultModelEnum.Product_Type_Not_Found, ResultModelEnum.Product_Type_Not_Found.ToString(), null);
                }
            }

            else
            {
                resultModel = new ResultModel((int)ResultModelEnum.Model_Invalid, ResultModelEnum.Model_Invalid.ToString(), null);
            }

            return resultModel;
        }

        [HttpPost]
        [Route("create-or-update-product-type")]
        public async Task<IResultModel> CreateOrUpdateProductType(int id, string name, int productId, bool isActive = true)
        {
            IResultModel resultModel;

            if (id >= 0 && productId > 0 && name != null)
            {
                if (id == 0)
                {
                    ProductType productType = new ProductType();

                    productType.Name = name;
                    productType.ProductId = productId;
                    productType.IsActive = isActive;

                    await _productTypeService.CreateItem(productType);

                    if (productType.Id > 0)
                    {
                        resultModel = new ResultModel((int)ResultModelEnum.Product_Type_Created, ResultModelEnum.Product_Type_Created.ToString(), productType);
                    }

                    else
                    {
                        resultModel = new ResultModel((int)ResultModelEnum.Transaction_Failed, ResultModelEnum.Transaction_Failed.ToString(), null);
                    }
                }

                else
                {
                    var productType = await _productTypeService.GetItem(id);

                    if (productType != null)
                    {
                        productType.Name = name;
                        productType.ProductId = productId;
                        productType.IsActive = isActive;

                        await _productTypeService.UpdateItem(productType);

                        resultModel = new ResultModel((int)ResultModelEnum.Product_Type_Updated, ResultModelEnum.Product_Type_Updated.ToString(), productType);
                    }

                    else
                    {
                        resultModel = new ResultModel((int)ResultModelEnum.Product_Not_Found, ResultModelEnum.Product_Not_Found.ToString(), null);
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
