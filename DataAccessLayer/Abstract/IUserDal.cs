using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IUserDal : IGenericCRUDDal<User>
    {
        public Task<bool> CheckUserEmailIsUniq(string email);
        public Task<bool> CheckUserPhoneIsUniq(string phone);
    }
}
