﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PrecioFishboneVietnamASP.NETTraining.Entities;
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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public Files(IItemRepository itemRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("{fileId}", Name = "GetFileById")]
        public async Task<IActionResult> GetFileById(int fileId)
        {
            var fileEntity = await _itemRepository.GetFile(fileId);
            return Ok(_mapper.Map<FileDto>(fileEntity));
        }

        [HttpPost("/upload")]
        public async Task<IActionResult> UploadFile([FromForm]FileForCreationDto fileForm, int folderId)
        {
            var fileEntity = await _itemRepository.UploadFile(fileForm, folderId);

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
