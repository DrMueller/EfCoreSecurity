using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Mmu.EfCoreSecurity.DataAccess.DbContexts.Interceptors
{
    public class SecurityInterceptor : DbCommandInterceptor, ISecurityInterceptor
    {
        public override DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
        {
            return base.ReaderExecuted(command, eventData, result);
        }
    }
}
