using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BufaloCargo.Models.Security
{
    public class ApplicationRole : IdentityRole
    {
        #region Properties
        [Required]
        [DisplayName("Rol")]
        public override required string Name { get; set; }
        #endregion

        #region AuditoryFields
        [DisplayName("Fecha de Creación")]
        [DataType(DataType.Date, ErrorMessage = "El formato debe ser aaaa-mm-dd")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd h:mm:ss tt}", ApplyFormatInEditMode = true)]
        public DateTime InsertDate { get; set; }

        [DisplayName("Fecha de Edición")]
        [DataType(DataType.Date, ErrorMessage = "El formato debe ser aaaa-mm-dd")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EditDate { get; set; }

        public string? UserCreate { get; set; }
        public string? UserEdit { get; set; }

        [DisplayName("Estado")]
        public bool Active { get; set; } = true;
        #endregion
    }
}
