using AutoMapper;
using PrecioFishboneVietnamASP.NETTraining.Entities;
using PrecioFishboneVietnamASP.NETTraining.Models;

namespace PrecioFishboneVietnamASP.NETTraining.Profiles
{
    public class FileProfile : Profile
    {
        public FileProfile ()
        {
            CreateMap<MyFile, FileDto>();
            CreateMap<FileForUpdateDto, MyFile>();
        }
    }
}
