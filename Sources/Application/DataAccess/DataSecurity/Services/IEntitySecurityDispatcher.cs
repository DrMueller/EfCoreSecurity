using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mmu.EfCoreSecurity.DataAccess.DataSecurity.Models;
using Mmu.EfCoreSecurity.DataAccess.Models.Base;

namespace Mmu.EfCoreSecurity.DataAccess.DataSecurity.Services
{
    public interface IEntitySecurityDispatcher
    {
        Task<EntityOperationCheckResult> CheckAuthorizationAsync<T>(EntityOperation operation, T entity)
            where T : EntityBase;

        IQueryable<T> AppendQuerySecurity<T>(DbSet<T> set)
            where T : EntityBase;
    }
}
