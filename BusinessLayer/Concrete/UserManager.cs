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

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
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

        public async Task<IResultModel> Register(UserRegisterDto userRegisterDto)
        {
            if (await _userDal.CheckUserPhoneIsUniq(userRegisterDto.Phone))
            {
                return new ResultModel((int)ResultModelEnum.Phone_Number_In_Use, ResultModelEnum.Phone_Number_In_Use.ToString(), null);
            }
            


            return new ResultModel(1, "", null);
        }
    }
}
