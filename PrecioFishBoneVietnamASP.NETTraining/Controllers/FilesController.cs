using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public Files(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        [HttpGet("{fileId}", Name = "GetFileById")]
        public async Task<IActionResult> GetFileById(int fileId)
        {
            var fileEntity = await _itemRepository.GetFile(fileId);
            return Ok(_mapper.Map<FileDto>(fileEntity));
        }

        [HttpPost("upload")]
        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> UploadFile([FromForm]FileForCreationDto fileForm)
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

        [HttpDelete("{fileId}")]
        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> DeleteFile(int fileId)
        {
            var fileEntity = await _itemRepository.GetFile(fileId);

            if (fileEntity == null)
            {
                return NotFound(new
                {
                    Message = "The file you try to delete may have been removed!"
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
