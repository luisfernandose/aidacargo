using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BufaloCargo.Models.Globals
{
    [Table("DocumentType", Schema = "Globals")]
    public class DocumentType : Basic
    {
        #region Properties
        [Key]
        public Guid IdDocumentType { get; set; }

        [DisplayName("Nombre")]
        [Required]
        public required string Name { get; set; }

        [DisplayName("Abreviatura")]
        [Required]
        public string? Abbreviation { get; set; }
        #endregion
    }
}
