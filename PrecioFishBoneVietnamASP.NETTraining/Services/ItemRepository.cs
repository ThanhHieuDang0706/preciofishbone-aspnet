﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrecioFishboneVietnamASP.NETTraining.DbContexts;
using PrecioFishboneVietnamASP.NETTraining.Entities;
using PrecioFishboneVietnamASP.NETTraining.Migrations;
using PrecioFishboneVietnamASP.NETTraining.Models;

namespace PrecioFishboneVietnamASP.NETTraining.Services
{
    public class ItemRepository : IItemRepository
    {
        private readonly ItemContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ItemRepository(ItemContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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
