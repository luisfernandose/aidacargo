using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BufaloCargo.Models.Globals
{
    [Table("Departments", Schema = "Globals")]
    public class Departments : Basic
    {
        #region Properties
        [Key]
        public Guid IdDepartment { get; set; }

        [DisplayName("Nombre")]
        public required string Name { get; set; }

        [DisplayName("Código")]
        public string? Code { get; set; }
        #endregion

        #region One to one relationship
        [DisplayName("País")]
        public required Guid CountryId { get; set; }
        public virtual Countrys? Countrys { get; set; }
        #endregion
    }
}
