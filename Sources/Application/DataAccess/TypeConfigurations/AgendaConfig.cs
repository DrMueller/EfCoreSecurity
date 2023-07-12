using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.EfCoreSecurity.DataAccess.Models;
using Mmu.EfCoreSecurity.DataAccess.TypeConfigurations.Base;

namespace Mmu.EfCoreSecurity.DataAccess.TypeConfigurations
{
    public class AgendaConfig : EntityConfigBase<Agenda>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Agenda> builder)
        {
            builder.Property(f => f.AgendaPoint).IsRequired();
            builder.Property(f => f.CreatedUserId).IsRequired();
        }
    }
}