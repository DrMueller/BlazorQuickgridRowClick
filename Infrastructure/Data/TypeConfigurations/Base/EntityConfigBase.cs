﻿using BlazorApp1.Infrastructure.Data.Models.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorApp1.Infrastructure.Data.TypeConfigurations.Base;

public abstract class EntityConfigBase<T> : IEntityTypeConfiguration<T>
    where T : Entity
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(f => f.Id);
        builder.Property(f => f.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(f => f.UpdatedDate).IsRequired();
        builder.Property(f => f.CreatedDate).IsRequired();

        ConfigureEntity(builder);
    }

    protected abstract void ConfigureEntity(EntityTypeBuilder<T> builder);
}