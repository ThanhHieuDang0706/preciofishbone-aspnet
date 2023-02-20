using PrecioFishboneVietnamASP.NETTraining.Entities;

namespace PrecioFishboneVietnamASP.NETTraining.Models
{
    public class FileDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public DateTime Modified { get; set; } = DateTime.Now;
        public string ModifiedBy { get; set; } = String.Empty;
        public Entities.Type ItemType { get; set; } = Entities.Type.File;

        public string FileExtension { get; set; } = null!;

        public string FileUrl { get; set; } = null!;
    }
}
