using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.Resource;
using PrecioFishboneVietnamASP.NETTraining.Entities;
using PrecioFishboneVietnamASP.NETTraining.Models;
using PrecioFishboneVietnamASP.NETTraining.Services;

namespace PrecioFishboneVietnamASP.NETTraining.Controllers
{
    [Route("api/folders")]
    [ApiController]
    [Authorize]
    public class FoldersController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public FoldersController(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        [HttpGet("{folderId}", Name = "GetFolderById")]
        [Authorize(Policy = "Member")]
        public async Task<IActionResult> GetFolderById(int folderId = -1, bool getWithItems = false)
        {
            try
            {
                // check if parentFolderId Exists
                var folder = await _itemRepository.GetFolder(folderId);
                
                if (folder == null)
                {
                    return NotFound(new
                    {
                        Message = "Current folder does not exist!"
                    });
                }

                if (getWithItems)
                {
                    var folderEntity = await _itemRepository.GetItemsInFolders(folderId);
                    return Ok(_mapper.Map<FolderWithItemsDto>(folderEntity));
                }

                return Ok(_mapper.Map<FolderDto>(folder));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> CreateFolder(FolderForCreationDto folder)
        {
            var parentFolder = await _itemRepository.GetFolder(folder.ParentFolderId);
            if (parentFolder == null)
            {
                return NotFound(new
                {
                    Message = "Current folder does not exist!"
                });
            }
            var folderEntity = _mapper.Map<Folder>(folder);
            await _itemRepository.AddFolder(folderEntity, folder.ParentFolderId);
            await _itemRepository.SaveAsync();

            var folderToReturn = _mapper.Map<FolderDto>(folderEntity);

            return CreatedAtRoute("GetFolderById", new { folderId = folderToReturn.Id }, folderToReturn);
        }

        [HttpDelete("{folderId}")]

        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> DeleteFolder(int folderId)
        {
            var folder = await _itemRepository.GetFolder(folderId);
            if (folder == null)
            {
                return NotFound(new
                {
                    Message = "The folder you try to delete may have been removed!"
                });
            }

            await _itemRepository.DeleteFolder(folderId);

            await _itemRepository.SaveAsync();

            return NoContent();
        }

    }

}
