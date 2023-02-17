using PrecioFishboneVietnamASP.NETTraining.DbContexts;
using PrecioFishboneVietnamASP.NETTraining.Entities;

namespace PrecioFishboneVietnamASP.NETTraining.Services
{
    public interface IItemRepository
    {
        Task<IEnumerable<MyFile>> GetFilesInFolder(int folderId);

        Task<IEnumerable<Folder>> GetFoldersInFolder(int folderId);

    }
}
