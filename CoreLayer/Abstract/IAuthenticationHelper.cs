using CoreLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Abstract
{
    public interface IAuthenticationHelper
    {
        public string CreateToken(string guid, int id);
        public CurrentUserModel GetCurrentUser();
    }
}
