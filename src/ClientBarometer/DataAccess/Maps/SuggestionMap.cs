using ClientBarometer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientBarometer.DataAccess.Maps
{
    public static class SuggestionMap
    {
        private static List<Suggestion> _vocabulary = new()
        {
            new Suggestion { ObjectionClass = "", Processing = "", Text = "" },
        };
        
        public static ModelBuilder Build<T>(this ModelBuilder modelBuilder) where T : Suggestion
        {
            var entityBuilder = modelBuilder.Entity<T>();

            // Main
            entityBuilder.ToTable("suggestion");

            // Indexes
            entityBuilder.HasIndex(_ => _.Id);

            // Values
            entityBuilder.Property(_ => _.Id)
                .ValueGeneratedOnAdd()
                .HasValueGenerator<GuidValueGenerator>();

            entityBuilder.Property(_ => _.RowVersion)
                .IsRowVersion();

            _vocabulary.ForEach((obj) => obj.Id = Guid.NewGuid());

            entityBuilder.HasData(_vocabulary);

            return modelBuilder;
        }
    }
}
