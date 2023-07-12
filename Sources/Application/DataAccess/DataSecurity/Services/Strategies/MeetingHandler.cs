using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mmu.EfCoreSecurity.Common.Security.Services;
using Mmu.EfCoreSecurity.DataAccess.DataSecurity.Models;
using Mmu.EfCoreSecurity.DataAccess.Models;

namespace Mmu.EfCoreSecurity.DataAccess.DataSecurity.Services.Strategies
{
    public class MeetingHandler : IEntitySecurityHandler<Meeting>
    {
        private readonly IUserProvider _userProvider;

        public MeetingHandler(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }

        public IQueryable<Meeting> ApplySelectSecurity(DbSet<Meeting> set)
        {
            var user = _userProvider.ProvideUser();
            if (user.IsAdmin)
            {
                return set;
            }

            return set.Where(f => f.Agenda.CreatedUserId == user.UserId);
        }

        public Task<EntityOperationCheckResult> CheckOperationAsync<T>(EntityOperation operation, T entity)
        {
            var user = _userProvider.ProvideUser();
            if (user.IsAdmin)
            {
                return Task.FromResult(EntityOperationCheckResult.Allowed);
            }

            return Task.FromResult(EntityOperationCheckResult.Disallowed);
        }
    }
}
