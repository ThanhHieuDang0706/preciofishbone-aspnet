namespace PrecioFishboneVietnamASP.NETTraining.Models
{
    public class FolderDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Modified { get; set; }
        public string ModifiedBy { get; set; } = null!;
        public Entities.Type ItemType { get; set; } = Entities.Type.Folder;
        
        public int? ParentFolderId { get; set; }
    }
}
