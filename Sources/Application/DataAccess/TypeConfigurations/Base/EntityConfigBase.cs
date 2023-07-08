using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.EfCoreSecurity.WebUI.DataAccess.Models.Base;

namespace Mmu.EfCoreSecurity.DataAccess.TypeConfigurations.Base
{
    public abstract class EntityConfigBase<T> : IEntityTypeConfiguration<T>
        where T : EntityBase
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            ConfigureEntity(builder);
        }

        protected abstract void ConfigureEntity(EntityTypeBuilder<T> builder);
    }
}