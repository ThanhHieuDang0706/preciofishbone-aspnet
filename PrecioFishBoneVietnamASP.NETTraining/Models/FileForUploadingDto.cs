using PrecioFishboneVietnamASP.NETTraining.Entities;
using Type = PrecioFishboneVietnamASP.NETTraining.Entities.Type;

namespace PrecioFishboneVietnamASP.NETTraining.Models
{
    public class FileForUploadingDto
    {
        public string Name { get; set; } = String.Empty;

        public DateTime Modified { get; set; }

        public string ModifiedBy { get; set; } = String.Empty;
        public string FileExtension { get; set; } = String.Empty;

        public DateTime CreatedTime { get; set; } = DateTime.Now;

        public int FolderId { get; set; }

        public string FileUrl { get; set; } = null!;
    }
}
