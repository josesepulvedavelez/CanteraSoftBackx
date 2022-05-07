using System;
namespace CanteraSoftBack.Models
{
    public class OperacionModel
    {
        public OperacionModel()
        {
        }

        public int OperacionId { get; set; }
        public string Numero { get; set; }
        public DateTime? Fecha { get; set; }
        public TimeSpan? Hora { get; set; }
        public double? Mt3Digitado { get; set; }
        public double? Mt3Capturado { get; set; }
        public double? Morro { get; set; }
        public int? ClienteId { get; set; }
        public int? ContratoId { get; set; }
        public int? MaterialId { get; set; }
        public int? VehiculoId { get; set; }
        public int? MaquinaId { get; set; }
        public int? EmpleadoId { get; set; }
        public int? Estado { get; set; }
        public string Observaciones { get; set; }
        public DateTime? FechaLog { get; set; }
        public string UsuarioLog { get; set; }
    }
}
