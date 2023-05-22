using BusinessLayer.Abstract;
using CoreLayer.Abstract;
using CoreLayer.Concrete;
using CoreLayer.Enums;
using EntityLayer.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImeceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;


        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("get-users")]
        public async Task<IResultModel> GetUsers()
        {
            var users = await _userService.GetItems();

            return new ResultModel((int)ResultModelEnum.Transaction_Success, ResultModelEnum.Transaction_Success.ToString(), users);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IResultModel> Register(UserRegisterDto userRegisterDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.Register(userRegisterDto);

                return result;
            }

            else
            {
                return new ResultModel((int)ResultModelEnum.Model_Invalid, ResultModelEnum.Model_Invalid.ToString(), null);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IResultModel> Login(string phone)
        {
            if (phone != null)
            {
                var result = await _userService.Login(phone);

                return result;
            }

            else
            {
                return new ResultModel((int)ResultModelEnum.Model_Invalid, ResultModelEnum.Model_Invalid.ToString(), null);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("create-admin")]
        public async Task<IResultModel> CreateAdmin(UserRegisterDto userRegisterDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.Register(userRegisterDto);

                return result;
            }

            else
            {
                return new ResultModel((int)ResultModelEnum.Model_Invalid, ResultModelEnum.Model_Invalid.ToString(), null);
            }
        }

    }
}
