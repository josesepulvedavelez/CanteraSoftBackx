using System;
namespace CanteraSoftBack.Models
{
    public class EmpleadoModel
    {
        public EmpleadoModel()
        {
        }

        public int EmpleadoId { get; set; }
        public string Nombres { get; set; }
        public string Cedula { get; set; }
        public string Cargo { get; set; }
        public int? Estado { get; set; }
        public string Observaciones { get; set; }
        public DateTime? FechaLog { get; set; }
        public string UsuarioLog { get; set; }
    }
}
