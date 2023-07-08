using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.EfCoreSecurity.DataAccess.TypeConfigurations.Base;
using Mmu.EfCoreSecurity.WebUI.DataAccess.Models;

namespace Mmu.EfCoreSecurity.DataAccess.TypeConfigurations
{
    public class AgendaConfig : EntityConfigBase<Agenda>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Agenda> builder)
        {
            builder.Property(f => f.AgendaPoint).IsRequired();
        }
    }
}