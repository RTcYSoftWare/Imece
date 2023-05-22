using CoreLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserService : IGenericService<User>
    {
        public Task<IResultModel> Register(UserRegisterDto userRegisterDto);
        public Task<User> GetUserByPhone(string phone);
        public Task<IResultModel> Login(string phone);
    }
}
