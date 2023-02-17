using Microsoft.EntityFrameworkCore;
using PrecioFishboneVietnamASP.NETTraining.DbContexts;
using PrecioFishboneVietnamASP.NETTraining.Entities;

namespace PrecioFishboneVietnamASP.NETTraining.Services
{
    public class ItemRepository : IItemRepository
    {
        private readonly ItemContext _context;

        public ItemRepository(ItemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MyFile>> GetFilesInFolder(int folderId)
        {
            return await _context.Files.Where(file => file.FolderId == folderId).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Folder>> GetFoldersInFolder(int parentFolderId)
        {
            return await _context.Folders.Where(folder => folder.ParentFolderId == parentFolderId).AsNoTracking().ToListAsync();
        }
    }
}
