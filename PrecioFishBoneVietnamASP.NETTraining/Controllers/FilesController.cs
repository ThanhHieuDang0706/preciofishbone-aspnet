using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PrecioFishboneVietnamASP.NETTraining.Models;
using PrecioFishboneVietnamASP.NETTraining.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrecioFishboneVietnamASP.NETTraining.Controllers
{
    [Route("api/folders/{folderId}/files")]
    [ApiController]
    public class Files : ControllerBase
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;
        public Files(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FileDto>>> GetFiles(int folderId)
        {
            try
            {
                var fileEntities = await _itemRepository.GetFilesInFolder(folderId);
                return Ok(_mapper.Map<IEnumerable<FileDto>>(fileEntities));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
