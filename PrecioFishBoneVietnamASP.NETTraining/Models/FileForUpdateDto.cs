namespace PrecioFishboneVietnamASP.NETTraining.Models
{
    public class FileForUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string FileExtension { get; set; } = String.Empty;
        public string ModifiedBy { get; set; }= String.Empty;
    }
}
