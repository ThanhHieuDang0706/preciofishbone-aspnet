namespace PrecioFishboneVietnamASP.NETTraining.Models
{
    public class FolderDto
    {
        public int Id { get; set; }
        public Entities.Type ItemType { get; set; } = Entities.Type.Folder;

        public int? ParentFolderId { get; set; }
        public string Name { get; set; } = String.Empty;

        public DateTime CreatedTime { get; set; }
        public DateTime Modified { get; set; }

        public string ModifiedBy { get; set; } = String.Empty;
    }
}
