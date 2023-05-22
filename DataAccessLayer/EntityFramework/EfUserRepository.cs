using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfUserRepository : GenericCRUDRepository<User>, IUserDal
    {
        private readonly ImeceDBContext _context;

        public EfUserRepository(ImeceDBContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckUserEmailIsUniq(string email)
        {
            return await _context.Users.AnyAsync(x => x.Email == email);
        }

        public async Task<bool> CheckUserPhoneIsUniq(string phone)
        {
            return await _context.Users.AnyAsync(x => x.Phone == phone);
        }

        public async Task<User> GetUserByPhone(string phone)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Phone == phone);
        }
    }
}
