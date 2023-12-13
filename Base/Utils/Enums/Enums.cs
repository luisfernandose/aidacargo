using System.ComponentModel.DataAnnotations;

namespace BufaloCargo.Utils.Enums
{
    public class Enums
    {
        public enum EnumLegalNature
        {
            [Display(Name = "Seleccione")]
            Seleccione,
            [Display(Name = "Privada")]
            Private,
            [Display(Name = "Pública")]
            Public,
            [Display(Name = "Mixta")]
            Mixed
        }

        public enum Roles
        {
            [Display(Name = "Super Administrador")]
            SuperAdmin,
            [Display(Name = "Administrador")]
            Administrador,
            [Display(Name = "Usuario de encuesta")]
            UserPoll
        }
    }
}
