﻿using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Collections.Core.Entities;

namespace SurveyStore.Modules.Collections.Infrastructure.EF
{
    public class CollectionsDbContext : DbContext
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<SurveyEquipment> SurveyEquipment { get; set; }
        public DbSet<Surveyor> Surveyors { get; set; }
        public CollectionsDbContext(DbContextOptions<CollectionsDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            modelBuilder.HasDefaultSchema("collections");
        }
    }
}