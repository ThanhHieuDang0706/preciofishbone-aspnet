using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrecioFishboneVietnamASP.NETTraining.Entities
{
    public enum Type {
        File,
        Folder
    }


    public class MyFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        public DateTime Modified { get; set; }

        [Required]
        public string ModifiedBy { get; set; } = null!;
        public Type ItemType { get; set; } = Type.File;
        public string FileExtension { get; set; } = null!;

        public int FolderId { get; set; }
        public Folder? CurrentFolder { get; set; }

    }
}
