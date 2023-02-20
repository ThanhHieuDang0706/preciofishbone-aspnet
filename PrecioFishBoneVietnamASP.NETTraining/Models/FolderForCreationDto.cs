namespace PrecioFishboneVietnamASP.NETTraining.Models
{
    public class FolderForCreationDto
    {
        public string Name { get; set; } = String.Empty;

        public string ModifiedBy { get; set; } = String.Empty;

        public int ParentFolderId { get; set; }
    }
}
