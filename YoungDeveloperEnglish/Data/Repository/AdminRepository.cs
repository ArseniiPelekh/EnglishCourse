using Data.Inteface;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDBContent _appDBContent;

    public async Task<bool> IsEmptyAdmin(string log, string pass)
        {
            var admin = await _appDBContent.Admins.FirstOrDefaultAsync(a => a.Login == log && a.Password == pass);
            return admin == null;
        }

        public async Task<bool> IsEmptyAdminLogin(string log)
        {
            var admin = await _appDBContent.Admins.FirstOrDefaultAsync(a => a.Login == log);
            return admin != null;
        }

        public AdminRepository(AppDBContent appDB)
        {
            _appDBContent = appDB;
        }

        public async Task AddAdmin(Admin admin)
        {
            _appDBContent.Admins.Add(admin);
            await _appDBContent.SaveChangesAsync();
        }

        public IQueryable<Admin> Admins()
        {
            return _appDBContent.Admins;
        }
    }
}
