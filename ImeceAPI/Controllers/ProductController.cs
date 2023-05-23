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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;


        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("get-products")]
        public async Task<IResultModel> GetProducts()
        {
            var products = await _productService.GetItems();

            return new ResultModel((int)ResultModelEnum.Transaction_Success, ResultModelEnum.Transaction_Success.ToString(), products);
        }

        [HttpGet]
        [Route("get-product")]
        public async Task<IResultModel> GetProduct(int id)
        {
            IResultModel resultModel;

            if (id > 0)
            {
                var product = await _productService.GetItem(id);

                if (product != null)
                {
                    resultModel = new ResultModel((int)ResultModelEnum.Transaction_Success, ResultModelEnum.Transaction_Success.ToString(), product);
                }

                else
                {
                    resultModel = new ResultModel((int)ResultModelEnum.Product_Not_Found, ResultModelEnum.Product_Not_Found.ToString(), null);
                }
            }

            else
            {
                resultModel = new ResultModel((int)ResultModelEnum.Model_Invalid, ResultModelEnum.Model_Invalid.ToString(), null);
            }

            return resultModel;
        }

        [HttpPost]
        [Route("create-or-update-product")]
        public async Task<IResultModel> CreateOrUpdateProduct(int id, string name, bool isActive = true)
        {
            IResultModel resultModel;

            if (id >= 0 && name != null)
            {
                if (id == 0)
                {
                    Product product = new Product();
                    
                    product.Name = name;
                    product.IsActive = isActive;                    

                    await _productService.CreateItem(product);

                    if (product.Id > 0)
                    {
                        resultModel = new ResultModel((int)ResultModelEnum.Product_Created, ResultModelEnum.Product_Created.ToString(), product);
                    }

                    else
                    {
                        resultModel = new ResultModel((int)ResultModelEnum.Transaction_Failed, ResultModelEnum.Transaction_Failed.ToString(), null);
                    }
                }

                else
                {
                    var product = await _productService.GetItem(id);

                    if (product != null)
                    {
                        product.Name = name;
                        product.IsActive = isActive;

                        await _productService.UpdateItem(product);

                        resultModel = new ResultModel((int)ResultModelEnum.Product_Updated, ResultModelEnum.Product_Updated.ToString(), product);
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
