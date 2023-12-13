using BufaloCargo.Models.Globals;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BufaloCargo.Models.Masters
{
    [Table("Campus", Schema = "Globals")]
    public class Campus : Basic
    {
        #region Properties
        [Key]
        public Guid IdSede { get; set; }

        [DisplayName("Nombre Sede")]
        [Required]
        public required string Name { get; set; }

        [DisplayName("Dirección")]
        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage = "No estan permitidos los caracteres especiales")]
        [Required]
        public string? Address { get; set; }

        [DisplayName("Telefono Fijo")]
        [Required]
        public string? Phone { get; set; }

        [DisplayName("Email")]
        [EmailAddress]
        public string? GeneralEmail { get; set; }

        [DisplayName("Celular")]
        public string? Mobile { get; set; }
        #endregion
    }
}
