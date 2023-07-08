using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.EfCoreSecurity.DataAccess.TypeConfigurations.Base;
using Mmu.EfCoreSecurity.WebUI.DataAccess.Models;

namespace Mmu.EfCoreSecurity.DataAccess.TypeConfigurations
{
    public class ParticipantConfig : EntityConfigBase<Participant>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Participant> builder)
        {
            builder.Property(f => f.Name).IsRequired();
        }
    }
}