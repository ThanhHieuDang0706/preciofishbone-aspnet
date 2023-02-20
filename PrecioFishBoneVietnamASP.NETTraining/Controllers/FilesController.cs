using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PrecioFishboneVietnamASP.NETTraining.Models;
using PrecioFishboneVietnamASP.NETTraining.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrecioFishboneVietnamASP.NETTraining.Controllers
{
    [Route("api/files")]
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
        public Task<IActionResult> GetFile(int fileId)
        {
            throw new NotImplementedException();
        }
    }
}
