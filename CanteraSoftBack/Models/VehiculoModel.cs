using System;
namespace CanteraSoftBack.Models
{
    public class VehiculoModel
    {
        public VehiculoModel()
        {
        }

        public int VehiculoId { get; set; }
        public string Placa { get; set; }
        public double? Mt3 { get; set; }
        public int? ClienteId { get; set; }
        public int? Estado { get; set; }
        public string Observaciones { get; set; }
        public DateTime? FechaLog { get; set; }
        public string UsuarioLog { get; set; }
    }
}
