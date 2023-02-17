using PrecioFishboneVietnamASP.NETTraining.Entities;

namespace PrecioFishboneVietnamASP.NETTraining.Models
{
    public class FileDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Modified { get; set; }
        public string ModifiedBy { get; set; } = null!;
        public Entities.Type ItemType { get; set; } = Entities.Type.File;
    }
}
