using PrecioFishboneVietnamASP.NETTraining.Entities;

namespace PrecioFishboneVietnamASP.NETTraining.Models
{
    public class FolderDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Modified { get; set; }
        public string ModifiedBy { get; set; } = null!;
        public Entities.Type ItemType { get; set; } = Entities.Type.Folder;

        public ICollection<Folder> Folders { get; set; } = new List<Folder>();

        public ICollection<MyFile> Files { get; set; } = new List<MyFile>();

        public int? ParentFolderId { get; set; }
    }
}
