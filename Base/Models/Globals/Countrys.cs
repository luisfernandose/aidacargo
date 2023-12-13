using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BufaloCargo.Models.Globals
{
    [Table("Countrys", Schema = "Globals")]
    public class Countrys : Basic
    {
        #region Properties
        [Key]
        public Guid IdCountry { get; set; }

        [Required]
        [DisplayName("Nombre")]
        public required string Name { get; set; }

        [DisplayName("Código")]
        public string? Code { get; set; }
        #endregion
    }
}
