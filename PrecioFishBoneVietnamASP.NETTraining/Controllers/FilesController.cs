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
        [Authorize(Roles = "Admin")]
        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:WriteFileScopes")]
        public async Task<IActionResult> UploadFile([FromForm]FileForCreationDto fileForm, int folderId)
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

    }
}
