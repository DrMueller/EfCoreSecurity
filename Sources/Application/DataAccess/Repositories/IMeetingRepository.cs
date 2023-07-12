using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mmu.EfCoreSecurity.DataAccess.Models;

namespace Mmu.EfCoreSecurity.DataAccess.Repositories
{
    public interface IMeetingRepository
    {
        Task SaveAsync(Meeting meeting);

        Task<Meeting> LoadAsync(long id);
    }
}
