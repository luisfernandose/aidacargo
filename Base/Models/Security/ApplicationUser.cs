using BufaloCargo.Models.Masters;
using BufaloCargo.Utils.Attributes;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BufaloCargo.Models.Security
{
    public class ApplicationUser : IdentityUser
    {
        #region Properties
        [Required]
        [DisplayName("Nombres")]
        public required string Names { get; set; }
        [Required]
        [DisplayName("Apellidos")]
        public required string SurNames { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public override required string Email { get; set; }

        [DisplayName("Dirección")]
        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage = "No estan permitidos los caracteres especiales")]
        public string? Address { get; set; }

        [DisplayName("Número Contacto")]
        public string? NumberContact { get; set; }

        [NotMapped]
        [DisplayName("Rol")]
        [NotEmpty]
        public Guid IdRol { get; set; }

        [DisplayName("Foto Perfil")]
        public string? ProfilePicture { get; set; }

        [NotMapped]
        [DisplayName("Foto Perfil")]
        public IFormFile? ProfileImage { get; set; }
        #endregion

        #region One To One Relationships

        [DisplayName("Empresa")]
        [NotEmpty]
        public Guid IdCompany { get; set; }
        public virtual Company? Company { get; set; }

        [DisplayName("Sede")]
        [NotEmpty]
        public Guid IdSede { get; set; }

        public virtual Campus? Campus { get; set; }
        #endregion

        #region NotMapped Fields
        [NotMapped]
        [DisplayName("Sedes Secundarias")]
        public List<Campus>? SedeList { get; set; }

        [NotMapped]
        [DisplayName("Nombre Rol")]
        public string? NameRol { get; set; }
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
