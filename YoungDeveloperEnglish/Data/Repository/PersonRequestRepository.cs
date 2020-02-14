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
    public class PersonRequestRepository : IPersonRequestRepository
    {
        private readonly AppDBContent _appDBContent;

        public PersonRequestRepository(AppDBContent appDB)
        {
            _appDBContent = appDB;
        }



        public async Task AddPersonRequest(PersonRequest personRequest)
        {
            await _appDBContent.PersonRequests.AddAsync(personRequest);
            await _appDBContent.SaveChangesAsync();
        }

        public async Task DeletePersonRequest(int id)
        {
            var _personRequest = await _appDBContent.PersonRequests.FirstOrDefaultAsync(a => a.Id == id);
            if (_personRequest != null)
            {
                _appDBContent.PersonRequests.Remove(_personRequest);
                await _appDBContent.SaveChangesAsync();
            }
        }

        public IQueryable<PersonRequest> PersonRequests()
        {
            return _appDBContent.PersonRequests;
        }
    }
}
