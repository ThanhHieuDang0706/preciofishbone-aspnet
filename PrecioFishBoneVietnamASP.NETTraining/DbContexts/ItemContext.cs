using Microsoft.EntityFrameworkCore;
using PrecioFishboneVietnamASP.NETTraining.Entities;

namespace PrecioFishboneVietnamASP.NETTraining.DbContexts
{
    public class ItemContext : DbContext
    {
        public DbSet<Folder> Folders { get; set; } = null!;
        public DbSet<MyFile> Files { get; set; } = null!;

        public ItemContext (DbContextOptions<ItemContext> options)
            : base(options)
        {

        }
    }
}
