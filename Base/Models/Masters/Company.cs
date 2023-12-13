using BufaloCargo.Models.Globals;
using BufaloCargo.Utils.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BufaloCargo.Utils.Enums.Enums;

namespace BufaloCargo.Models.Masters
{
    public class Company : Basic
    {
        #region Properties

        #region Bussines Information
        [Key]
        public Guid IdCompany { get; set; }

        [DisplayName("Documento/Nit")]
        public required string Document { get; set; }

        [DisplayName("Verificación Nit")]
        public string? VerificationNit { get; set; }

        [DisplayName("Razón Social")]
        [Required]
        public required string BusinessName { get; set; }

        [DisplayName("Naturaleza Jurídica")]
        public EnumLegalNature EnumLegalNature { get; set; }

        [Required]
        [DisplayName("Correo Administrador")]
        [EmailAddressAttribute]
        public required string MailAdmin { get; set; }
        #endregion

        #region Ubication
        [DisplayName("Dirección")]
        [Column("address")]
        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage = "No estan permitidos los caracteres especiales")]
        public string? Address { get; set; }

        [DisplayName("Celular")]
        public string? Mobile { get; set; }

        [DisplayName("Teléfono")]
        [Column("phone")]
        public string? Phone { get; set; }

        [DisplayName("Correo Empresa")]
        [DataType(DataType.EmailAddress)]
        public string? CompanyEmail { get; set; }
        #endregion

        #region Legal representative
        [DisplayName("Primer Nombre")]
        [Required]
        public required string RepresentativeName { get; set; }

        [DisplayName("Segundo Nombre")]
        public required string RepresentativeSecondName { get; set; }

        [DisplayName("Primer Apellido")]
        [Required]
        public required string RepresentativeSurName { get; set; }

        [DisplayName("Segundo Apellido")]
        public required string RepresentativeSecondSurName { get; set; }

        [DisplayName("Documento Representante")]
        public required string RepresentativeDocument { get; set; }
        #endregion

        #endregion

        #region One To One Relationships
        [DisplayName("Tipo de Identificación")]
        [NotEmpty]
        public required Guid IdDocumentTypeCompany { get; set; }

        public virtual DocumentType? DocumentTypeCompany { get; set; }
        #endregion
    }
}
