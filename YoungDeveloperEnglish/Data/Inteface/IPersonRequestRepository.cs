using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Inteface
{
    public interface IPersonRequestRepository
    {
        IQueryable<PersonRequest> PersonRequests();

        Task AddPersonRequest(PersonRequest personRequest);

        Task DeletePersonRequest(int id);
    }
}
