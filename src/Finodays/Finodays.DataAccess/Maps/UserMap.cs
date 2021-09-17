using System;
using Finodays.Domain.Constants;
using Finodays.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Finodays.DataAccess.Maps
{
    public static class UserMap
    {
        public static ModelBuilder Build<T>(this ModelBuilder modelBuilder) where T: User
        {
            var entityBuilder = modelBuilder.Entity<T>();

            // Main
            entityBuilder.ToTable("finodays_users");

            // Indexes
            entityBuilder.HasIndex(_ => _.Id);
            entityBuilder.HasIndex(_ => _.IntId);

            // Values
            entityBuilder.Property(_ => _.Id)
                .ValueGeneratedOnAdd()
                .HasValueGenerator<GuidValueGenerator>();

            entityBuilder.Property(_ => _.RowVersion)
                .IsRowVersion();

            return modelBuilder;
        }
    }
}
