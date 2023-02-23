using Microsoft.AspNetCore.Mvc;
using PrecioFishboneVietnamASP.NETTraining.DbContexts;
using PrecioFishboneVietnamASP.NETTraining.Entities;
using PrecioFishboneVietnamASP.NETTraining.Models;

namespace PrecioFishboneVietnamASP.NETTraining.Services
{
    public interface IItemRepository
    {
        // Files
        Task<Folder?> GetItemsInFolders(int folderId);
        Task<MyFile?> UploadFile([FromForm]FileForCreationDto fileForm);
        Task<MyFile> GetFile (int fileId);

        Task DeleteFile(int fileId);

        // Folders
        Task<Folder?> GetFolder(int folderId);
        Task AddFolder(Folder folder, int parentFolderId);

        Task DeleteFolder(int folderId);

        Task<bool> SaveAsync();
    }
}
