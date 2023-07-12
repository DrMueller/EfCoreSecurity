using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.EfCoreSecurity.DataAccess.Models;
using Mmu.EfCoreSecurity.DataAccess.TypeConfigurations.Base;

namespace Mmu.EfCoreSecurity.DataAccess.TypeConfigurations;

public class MeetingConfig : EntityConfigBase<Meeting>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Meeting> builder)
    {
        builder
            .Property(f => f.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(f => f.MeetingType)
            .IsRequired();

        builder
            .HasMany(f => f.Participants)
            .WithOne()
            .IsRequired();

        builder.HasOne(f => f.Agenda)
            .WithOne()
            .HasForeignKey<Agenda>(f => f.MeetingId)
            .IsRequired();
    }
}