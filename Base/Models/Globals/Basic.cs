using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BufaloCargo.Models.Globals
{
    public class Basic
    {
        public Basic()
        {
            InsertDate = DateTime.Now;
            EditDate = DateTime.Now;
            Active = true;
        }
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
    }
}
