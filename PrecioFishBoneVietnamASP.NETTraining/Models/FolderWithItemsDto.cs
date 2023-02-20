using PrecioFishboneVietnamASP.NETTraining.Entities;

namespace PrecioFishboneVietnamASP.NETTraining.Models
{
    public class FolderWithItemsDto
    {
        public int Id { get; set; }
        public Entities.Type ItemType { get; set; } = Entities.Type.Folder;

        public ICollection<FolderDto> Folders { get; set; } = new List<FolderDto>();

        public ICollection<MyFile> Files { get; set; } = new List<MyFile>();

        public int? ParentFolderId { get; set; }
    }
}
