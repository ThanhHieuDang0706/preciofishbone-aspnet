
using Microsoft.EntityFrameworkCore;
using PrecioFishboneVietnamASP.NETTraining.Entities;

using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace PrecioFishboneVietnamASP.NETTraining.DbContexts
{
    public class ItemContext : DbContext
    {
        public DbSet<Folder> Folders { get; set; } = null!;
        public DbSet<MyFile> Files { get; set; } = null!;

        public ItemContext(DbContextOptions<ItemContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // init table
            modelBuilder.Entity<Folder>().ToTable(nameof(Folder));
            modelBuilder.Entity<MyFile>().ToTable(nameof(MyFile));
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