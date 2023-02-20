using PrecioFishboneVietnamASP.NETTraining.DbContexts;
using PrecioFishboneVietnamASP.NETTraining.Entities;

namespace PrecioFishboneVietnamASP.NETTraining.Services
{
    public interface IItemRepository
    {
        // Files
        Task<Folder?> GetItemsInFolders(int folderId);

        // Folders
        Task<Folder?> GetFolder(int folderId);
        Task AddFolder(Folder folder, int parentFolderId);
        Task<bool> SaveAsync();
    }
}
