﻿using Microsoft.EntityFrameworkCore;
using PrecioFishboneVietnamASP.NETTraining.Entities;

namespace PrecioFishboneVietnamASP.NETTraining.DbContexts
{
    public class ItemContext : DbContext
    {
        public DbSet<Folder> Folders { get; set; } = null!;
        public DbSet<MyFile> Files { get; set; } = null!;

        public ItemContext(DbContextOptions<ItemContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Folder>()
                .HasMany(folder => folder.Folders)
                .WithOne(folder => folder.ParentFolder)
                .HasForeignKey(folder => folder.ParentFolderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Folder>()
                .HasMany(folder => folder.Files)
                .WithOne(file => file.CurrentFolder!)
                .HasForeignKey(file => file.FolderId)
                .OnDelete(DeleteBehavior.Cascade);

            // initialize root folder
            modelBuilder.Entity<Folder>().HasData(Folder.TopFolder);
            base.OnModelCreating(modelBuilder);
        }
    }
}