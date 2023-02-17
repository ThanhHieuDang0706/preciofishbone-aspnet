using AutoMapper;
using PrecioFishboneVietnamASP.NETTraining.Entities;
using PrecioFishboneVietnamASP.NETTraining.Models;

namespace PrecioFishboneVietnamASP.NETTraining.Profiles
{
    public class FileProfiles : Profile
    {
        public FileProfiles ()
        {
            CreateMap<MyFile, FileDto>();
        }
    }
}
