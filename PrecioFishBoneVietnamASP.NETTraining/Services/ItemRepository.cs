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

        public async Task<Folder?> GetItemsInFolders(int folderId)
        {
            return await _context.Folders
                .Where(folder => folder.Id == folderId)
                .Include(folder => folder.Files)
                .Include(folder => folder.Folders)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        /// Get data only in Folders table
        public async Task<Folder?> GetFolder(int folderId)
        {
            return await _context.Folders
                .Where(folder => folder.Id == folderId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task AddFolder(Folder folder, int parentFolderId)
        {
            var parentFolder = await _context.Folders.Where(f => f.Id == parentFolderId).FirstOrDefaultAsync();
            if (parentFolder != null)
            {
                parentFolder.Folders.Add(folder);
            }
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
