using System;
using Finodays.Domain.Constants;
using Finodays.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Finodays.DataAccess.Maps
{
    public static class TransactionMap
    {
        public static ModelBuilder Build<T>(this ModelBuilder modelBuilder) where T: Transaction
        {
            var entityBuilder = modelBuilder.Entity<T>();

            // Main
            entityBuilder.ToTable("finodays_transactions");

            // Indexes
            entityBuilder.HasIndex(_ => _.Id);
            entityBuilder.HasIndex(_ => _.UserId);
            entityBuilder.HasIndex(_ => _.UserIntId);

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
