using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Inteface
{
    public interface IAdminRepository
    {
        Task AddAdmin(Admin admin);

        // Task<IEnumerable<Admin>> Admins { get; }

        IQueryable<Admin> Admins();

        Task<bool> IsEmptyAdmin(string log, string pass);

        Task<bool> IsEmptyAdminLogin(string log);
    }
}
