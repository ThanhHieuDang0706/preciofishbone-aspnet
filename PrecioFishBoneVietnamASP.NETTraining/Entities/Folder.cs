using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PrecioFishboneVietnamASP.NETTraining.Entities
{
    public class Folder
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
        public Type ItemType { get; set; } = Type.Folder;
        public ICollection<Folder> Folders { get; set; } = new List<Folder>();

        public ICollection<MyFile> Files { get; set; } = new List<MyFile>();

        public int ParentFolderId { get; set; } 

        public Folder? ParentFolder { get; set; }
    }
}
