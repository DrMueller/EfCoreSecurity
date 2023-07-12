using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.EfCoreSecurity.DataAccess.Models;
using Mmu.EfCoreSecurity.DataAccess.TypeConfigurations.Base;

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