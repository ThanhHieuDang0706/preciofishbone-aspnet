using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PrecioFishboneVietnamASP.NETTraining.Models;
using PrecioFishboneVietnamASP.NETTraining.Services;

namespace PrecioFishboneVietnamASP.NETTraining.Controllers
{
    [Route("api/folders/{parentFolderId}/folders")]
    [ApiController]
    public class FoldersController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public FoldersController(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FolderDto>>> GetFolders(int parentFolderId)
        {
            try
            {
                var folderEntities = await _itemRepository.GetFoldersInFolder(parentFolderId);
                return Ok(_mapper.Map<IEnumerable<FolderDto>>(folderEntities));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

}
