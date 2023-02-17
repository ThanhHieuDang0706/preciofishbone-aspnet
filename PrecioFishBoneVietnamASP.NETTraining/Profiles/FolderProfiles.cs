using AutoMapper;
using PrecioFishboneVietnamASP.NETTraining.Entities;
using PrecioFishboneVietnamASP.NETTraining.Models;

namespace PrecioFishboneVietnamASP.NETTraining.Profiles
{
    public class FolderProfiles : Profile
    {
        public FolderProfiles()
        {
            CreateMap<Folder, FolderDto>();
        }
    }
}
