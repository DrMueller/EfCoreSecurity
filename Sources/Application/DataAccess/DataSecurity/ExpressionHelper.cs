using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.EfCoreSecurity.DataAccess.DataSecurity
{
    internal static class ExpressionHelper
    {
        internal static Expression<Func<T, bool>> FalseExpr<T>()
        {
            return f => false;
        }
    }
}
