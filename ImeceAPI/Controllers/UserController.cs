using BusinessLayer.Abstract;
using CoreLayer.Abstract;
using EntityLayer.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImeceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;


        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IResultModel> Register(UserRegisterDto userRegisterDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.Register(userRegisterDto);
            }

            return null;
        }
    }
}
