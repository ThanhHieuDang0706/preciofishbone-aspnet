namespace PrecioFishboneVietnamASP.NETTraining.Models
{
    public class FolderForCreationDto
    {
        public string Name { get; set; } = String.Empty;

        public string Modified { get; set; } = String.Empty;

        public int ParentFolderId { get; set; }
    }
}
