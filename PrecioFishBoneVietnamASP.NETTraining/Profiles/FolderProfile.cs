using AutoMapper;
using PrecioFishboneVietnamASP.NETTraining.Entities;
using PrecioFishboneVietnamASP.NETTraining.Models;

namespace PrecioFishboneVietnamASP.NETTraining.Profiles
{
    public class FolderProfile : Profile
    {
        public FolderProfile()
        {
            CreateMap<Folder, FolderWithItemsDto>();
            CreateMap<Folder, FolderDto>();
            CreateMap<FolderForCreationDto, Folder>();
            CreateMap<FolderForUpdateDto, Folder>();
        }
    }
}
