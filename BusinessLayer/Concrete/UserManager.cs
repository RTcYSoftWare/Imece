using BusinessLayer.Abstract;
using CoreLayer.Abstract;
using CoreLayer.Concrete;
using CoreLayer.Enums;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IAuthenticationHelper _authenticationHelper;



        public UserManager(IUserDal userDal, IAuthenticationHelper authenticationHelper)
        {
            _userDal = userDal;
            _authenticationHelper = authenticationHelper;
        }

        public async Task<User> CreateItem(User item)
        {
            return await _userDal.CreateItem(item);
        }

        public Task<User> DeleteItem(User item)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetItem(int id)
        {
            return await _userDal.GetItem(id);
        }

        public async Task<List<User>> GetItems()
        {
            return await _userDal.GetItems();
        }

        public async Task<User> UpdateItem(User item)
        {
            return await _userDal.UpdateItem(item);
        }

        public async Task<User> GetUserByPhone(string phone)
        {
            return await _userDal.GetUserByPhone(phone);
        }

        public async Task<IResultModel> Login(string phone)
        {
            var user = await _userDal.GetUserByPhone(phone);

            if (user != null)
            {
                user.Token = _authenticationHelper.CreateToken(user.Guid.ToString(), user.Id);

                return new ResultModel((int)ResultModelEnum.Transaction_Success, ResultModelEnum.Transaction_Success.ToString(), user);
            }

            else
            {
                return new ResultModel((int)ResultModelEnum.User_Not_Found, ResultModelEnum.User_Not_Found.ToString(), null);
            }
        }

        public async Task<IResultModel> Register(UserRegisterDto userRegisterDto)
        {
            if (await _userDal.CheckUserPhoneIsUniq(userRegisterDto.Phone))
            {
                return new ResultModel((int)ResultModelEnum.Phone_Number_In_Use, ResultModelEnum.Phone_Number_In_Use.ToString(), null);
            }

            else
            {
                User user = new User();

                user.Guid = Guid.NewGuid();
                user.Name = userRegisterDto.Name;
                user.Surname = userRegisterDto.Surname;
                user.Phone = userRegisterDto.Phone;
                user.Password = "";
                user.PasswordHashKey = "";
                user.UserType = userRegisterDto.UserType;

                user.Token = _authenticationHelper.CreateToken(user.Guid.ToString(), user.Id);

                await _userDal.CreateItem(user);

                if (user.Id > 0)
                {
                    return new ResultModel((int)ResultModelEnum.Transaction_Success, ResultModelEnum.Transaction_Success.ToString(), user);
                }

                else
                {
                    return new ResultModel((int)ResultModelEnum.Transaction_Failed, ResultModelEnum.Transaction_Failed.ToString(), null);
                }
            }
        }
    }
}
