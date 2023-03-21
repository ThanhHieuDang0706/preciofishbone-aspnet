namespace PrecioFishboneVietnamASP.NETTraining.Models
{
    public class FileForCreationDto
    {
        public DateTime Modified { get; set; } = DateTime.Now;
        public string ModifiedBy { get; set; } = String.Empty;

        public int FolderId { get; set; }

        public DateTime CreatedTime { get; set; } = DateTime.Now;

        public IFormFile File { get; set; } = null!;
    }
}
