using System.Runtime.CompilerServices;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Microsoft.Identity.Web.Resource;
using PrecioFishboneVietnamASP.NETTraining.Entities;
using PrecioFishboneVietnamASP.NETTraining.Models;
using PrecioFishboneVietnamASP.NETTraining.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrecioFishboneVietnamASP.NETTraining.Controllers
{
    [Route("api/files")]
    [ApiController]
    [Authorize]
    public class Files : ControllerBase
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;
        public Files(IItemRepository itemRepository, IMapper mapper, FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider;
        }

        [HttpGet("{fileId}", Name = "GetFileById")]
        public async Task<IActionResult> GetFileById(int fileId)
        {
            var fileEntity = await _itemRepository.GetFile(fileId);
            return Ok(_mapper.Map<FileDto>(fileEntity));
        }

        [HttpGet("{fileId}/download")]
        [Authorize(Policy = "Member")]
        public async Task<IActionResult> DownloadFile(int fileId)
        {
            var fileEntity = await _itemRepository.GetFile(fileId);
            if (fileEntity == null)
            {
                return NotFound(new
                {
                    Message = "This file may have been removed!"
                });
            }

            if (!_fileExtensionContentTypeProvider.TryGetContentType(fileEntity.FileUrl, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(fileEntity.FileUrl);
            return File(bytes, contentType, $"{fileEntity.Name}{fileEntity.FileExtension}");
        }


        [HttpPost("upload")]
        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> UploadFile([FromForm] FileForCreationDto fileForm)
        {
            var fileEntity = await _itemRepository.UploadFile(fileForm);

            if (fileEntity == null)
            {
                return NotFound(new
                {
                    Message = "Folder not found"
                });
            }

            var fileToReturn = _mapper.Map<FileDto>(fileEntity);

            return CreatedAtRoute("GetFileById", new { fileId = fileToReturn.Id }, fileToReturn);
        }

        [HttpPut]
        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> UpdateFile(FileForUpdateDto file)
        {
            var fileEntity = await _itemRepository.GetFile(file.Id);
            if (fileEntity == null)
            {
                return NotFound(new
                {
                    Message = "This file may have been removed!"
                });
            }
            await _itemRepository.UpdateFile(file);
            await _itemRepository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{fileId}")]
        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> DeleteFile(int fileId)
        {
            var fileEntity = await _itemRepository.GetFile(fileId);

            if (fileEntity == null)
            {
                return NotFound(new
                {
                    Message = "The file you try to delete may have already been removed!"
                });
            }

            await _itemRepository.DeleteFile(fileId);

            if (!await _itemRepository.SaveAsync())
            {
                throw new Exception("Deleting file failed on save.");
            }

            return NoContent();
        }

    }
}
