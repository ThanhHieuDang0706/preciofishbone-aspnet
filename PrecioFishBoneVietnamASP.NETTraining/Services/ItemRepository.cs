using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrecioFishboneVietnamASP.NETTraining.DbContexts;
using PrecioFishboneVietnamASP.NETTraining.Entities;
using PrecioFishboneVietnamASP.NETTraining.Models;

namespace PrecioFishboneVietnamASP.NETTraining.Services
{
    public class ItemRepository : IItemRepository
    {
        private readonly ItemContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;
        public ItemRepository(ItemContext context, IWebHostEnvironment webHostEnvironment, IMapper mapper)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
        }

        public async Task<MyFile?> UploadFile([FromForm]FileForCreationDto fileForm)
        {
            var file = fileForm.File;
            var folderId = fileForm.FolderId;
            var folder = await _context.Folders.Where(f => f.Id == folderId).FirstOrDefaultAsync();
            if (folder != null)
            {
                var addFileDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "public", "uploads");

                if (!Directory.Exists(addFileDirectory))
                {
                    Directory.CreateDirectory(addFileDirectory);
                }

                var fileEntity = new MyFile
                {
                    Name = Path.GetFileNameWithoutExtension(file.FileName),
                    Modified = DateTime.Now,
                    ModifiedBy = fileForm.ModifiedBy,
                    FileExtension = Path.GetExtension(file.FileName),
                    FileUrl = Path.Combine(_webHostEnvironment.WebRootPath, "public", "uploads", file.FileName),
                    CreatedTime = DateTime.Now,
                    FolderId = folderId
                };

                folder.Files.Add(fileEntity);
                await _context.SaveChangesAsync();

                using (var fileStream = new FileStream(fileEntity.FileUrl, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                return fileEntity;
            }

            return null;
        }

        public async Task<MyFile?> GetFile(int fileId)
        {
            return await _context.Files
                .Where(file => file.Id == fileId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        
        }

        public async Task DeleteFile(int fileId)
        {
            var file = await _context.Files.Where(f => f.Id == fileId).FirstOrDefaultAsync();
            if (file != null)
            {
                _context.Files.Remove(file);
            }
        }

        public async Task UpdateFile(FileForUpdateDto file)
        {
            var fileEntity = await _context.Files.Where(f => f.Id == file.Id).FirstOrDefaultAsync();
            
            if (fileEntity != null)
            {
                fileEntity.Modified = DateTime.Now;
                _mapper.Map(file, fileEntity);
            }
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

        public async Task DeleteFolder(int folderId)
        {
            var folder = await _context.Folders.Where(f => f.Id == folderId).FirstOrDefaultAsync();
            if (folder != null)
            {
                _context.Folders.Remove(folder);
            }
        }

        public async Task UpdateFolder(FolderForUpdateDto folderUpdate)
        {
            var folder = await _context.Folders.Where(f => f.Id == folderUpdate.Id).FirstOrDefaultAsync();
            if (folder != null)
            {
                folder.Modified = DateTime.Now;
                _mapper.Map(folderUpdate, folder);
            }
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
