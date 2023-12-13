using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BufaloCargo.Models.Globals
{
    [Table("Municipalities", Schema = "Globals")]
    public class Municipalities : Basic
    {
        #region Properties
        [Key]
        public Guid IdMunicipality { get; set; }

        [DisplayName("Nombre")]
        public required string Name { get; set; }

        [DisplayName("Código")]
        public string? Code { get; set; }
        #endregion

        #region One to one relationship
        [DisplayName("País")]
        public required Guid IdDepartments { get; set; }
        public virtual Departments? Departments { get; set; }
        #endregion
    }
}
